using GestionDesAbsencesv1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Windows.Shapes;

namespace GestionDesAbsencesv1.ViewModels
{
    class StudentViewModel : INotifyPropertyChanged
    {
        User _user;
        DateTime _dateStart = new(DateTime.Now.Year, 1, 1);
        DateTime _dateEnd   = new(DateTime.Now.Year, 12, 31);
        List<Attendance> _userAttendance;
        double _numbersDaysAbsence;
        double _numberTrainingDays;
        List<Attendance> _absenceJustified;
        List<Attendance> _absenceNotJustified;
        double _txAbsent;

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public User UserConnected
        {
            set
            {
                _user = value;
            }
        }

        public List<Attendance> AbsenceJustified
        {
            get
            {
                return _absenceJustified;
            }
            set
            {
                _absenceJustified = value;
                OnPropertyChanged(nameof(AbsenceJustified));
            }
        }

        public List<Attendance> AbsenceNotJustified
        {
            get
            {
                return _absenceNotJustified;
            }
            set
            {
                _absenceNotJustified = value;
                OnPropertyChanged(nameof(AbsenceNotJustified));
            }
        }

        public DateTime DateStart
        {
            get
            {
                return _dateStart;
            }
            set
            {
                _dateStart = value;
            }
        }

        public DateTime DateEnd
        {
            get
            {
                return _dateEnd;
            }
            set
            {
                _dateEnd = value;
            }
        }
        public string AbsenteeismRate
        {
            get
            {
                return _txAbsent.ToString();
            }
            set
            {
                _txAbsent = Double.Parse(value);
                OnPropertyChanged(nameof(AbsenteeismRate));
            }
        }

        public double TxAbsent
        {
            get
            {
                return _txAbsent;
            }
            set
            {
                _txAbsent = value;
                OnPropertyChanged("txAbsent");
            }
        }

        public double NumbersDaysAbsence
        {
            get => _numbersDaysAbsence;
            set 
            { 
                _numbersDaysAbsence = value; 
                OnPropertyChanged(nameof(NumbersDaysAbsence)); 
            }
        }

        public double NumberTrainingDays
        {
            get => _numberTrainingDays;
            set 
            { 
                _numberTrainingDays = value; 
                OnPropertyChanged(nameof(NumberTrainingDays)); 
            }
        }

        void SetListAttendance()
        {
            _userAttendance = _user.Attendances
                .Where(c => DateTime.Parse(c.Seance.Datetime) >= _dateStart)
                .Where(x => DateTime.Parse(x.Seance.Datetime) <= _dateEnd)
                .ToList();
        }

        public void StartHomeStudent()
        {
            SetListAttendance();
            SetListAbsenceJustified();
            SetListAbsenceNotJustified();
            _numbersDaysAbsence = GetAbsenceDays();
            _numberTrainingDays = GetAllDaysTraining();
            _txAbsent = GetAbsenteeismRate();
        }

        void SetListAbsenceJustified()
        {
            AbsenceJustified = _userAttendance.Where(c => c.Proof != null && c.Proof.Justify == true).ToList();
        }

        void SetListAbsenceNotJustified()
        {
            AbsenceNotJustified = _userAttendance
                .Where(x=> x.MissingType > 0 )
                .Where(c => c.Proof != null && c.Proof.Justify == false || c.Proof == null)
                .ToList();
        }

        double GetAbsenteeismRate()
        {
            double nb = GetAbsenceDays() / GetAllDaysTraining();
            double tx = nb * 100;
            return tx;
        }

        int GetAllDaysTraining() => _userAttendance.Count;
        double GetAbsenceDays() => _userAttendance
                .Where(c => c.MissingType > 0)
                .Sum(x=>x.MissingType);

        public void FilterDataDate()
        {
            _userAttendance = _user.Attendances
                .Where(c => DateTime.Parse(c.Seance.Datetime) >= _dateStart)
                .Where(x => DateTime.Parse(x.Seance.Datetime) <= _dateEnd)
                .ToList();
            NumbersDaysAbsence = GetAbsenceDays();
            NumberTrainingDays = GetAllDaysTraining();
            AbsenteeismRate = GetAbsenteeismRate().ToString();
            TxAbsent = GetAbsenteeismRate();
        }

        public void GeneratePdf()
        {
            string outfile = Environment.CurrentDirectory + $"/AbsenceDu{_dateStart.Day}.{_dateStart.Month}au{_dateEnd.Day}.{_dateEnd.Month}.pdf";

            //Création du document
            Document doc = new();
            PdfWriter.GetInstance(doc, new FileStream(outfile, FileMode.Create));
            doc.Open();

            //palette couleur
            BaseColor blue = new(4, 21, 59);
            BaseColor blueLight = new(68, 92, 145);
            BaseColor grey = new(160, 159, 159);
            BaseColor red = new(254, 0, 26);
            BaseColor white = new(255, 255, 255);


            //police d'écriture
            Font fontTitre = new(iTextSharp.text.Font.FontFamily.HELVETICA, 20f, 5, blue);
            Font fontSubTitle = new(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, 7, blue);
            Font fontSubText = new(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, 0, blueLight);
            Font fontTh = new(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, 1, white);
            Font fontSubTh = new(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, 0, blue);

            string logoPatch = @"C:\Users\boyer\source\repos\GestionDesAbsences\GestionDesAbsencesv1\Assets\logo.png";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(logoPatch);
            jpg.Alignment = Element.ALIGN_CENTER;
            jpg.ScaleToFit(50f, 50f);
            doc.Add(jpg);

            //page
            Paragraph p1 = new("LISTE DES ABSENCES\n", fontTitre);
            p1.Alignment = Element.ALIGN_CENTER;
            doc.Add(p1);

            Paragraph p2 = new($"\nElève :\n", fontSubTitle);
            p2.Alignment = Element.ALIGN_LEFT;
            doc.Add(p2);
            Paragraph p2b = new($"{_user.FirstName} {_user.LastName}\n{_user.Mail}\n\n", fontSubText);
            p2b.Alignment = Element.ALIGN_LEFT;
            doc.Add(p2b);

            Paragraph p3 = new($"Période :\n", fontSubTitle);
            p3.Alignment = Element.ALIGN_LEFT;
            doc.Add(p3);
            Paragraph p3b = new($"Du : {_dateStart} Au : {_dateEnd}\n", fontSubText);
            p3b.Alignment = Element.ALIGN_LEFT;
            doc.Add(p3b);

            Paragraph p4 = new("\n");
            doc.Add(p4);

            //tableau
            PdfPTable table = new(5);
            table.WidthPercentage = 100;

            //cell tab 
            AddCellToTab("Date Absence", fontTh, blue, table);
            AddCellToTab("Type Absence", fontTh, blue, table);
            AddCellToTab("Cour", fontTh, blue, table);
            AddCellToTab("Motif", fontTh, blue, table);
            AddCellToTab("Justifié", fontTh, blue, table);

            foreach(Attendance attd in _userAttendance.Where(c => c.MissingType > 0).ToList())
            {
                string[] absenceInfo = new string[5];
                absenceInfo[0] = attd.Seance.Datetime;
                absenceInfo[1] = attd.MissingType.ToString();
                absenceInfo[2] = attd.Seance.Label;
                if(attd.Proof != null)
                {
                    absenceInfo[3] = attd.Proof.Motive;
                    if(attd.Proof.Justify == true)
                    {
                        absenceInfo[4] = "oui";
                    }
                    else
                    {
                        absenceInfo[4] = "non";
                    }
                } 
                else
                {
                    absenceInfo[3] = null;
                    absenceInfo[4] = "non";
                }



                foreach(string info in absenceInfo)
                {
                    AddCellToTab(info, fontSubTh, white, table);
                }
            }

            doc.Add(table);

            doc.Close();
            Process.Start(@"cmd.exe ", @"/c " + outfile);

        }
        
        static void AddCellToTab(string str, Font f, BaseColor c, PdfPTable t)
        {
            PdfPCell cell = new(new Phrase(str, f));
            cell.BackgroundColor = c;
            cell.VerticalAlignment = Element.ALIGN_CENTER;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 5;
            t.AddCell(cell);
        }

    }
}
