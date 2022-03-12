using GestionDesAbsencesv1.Models;
using GestionDesAbsencesv1.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesv1.ViewModels
{
    class ProofViewModel
    {
        readonly DbSet<Proof> DBPROOF = Db.Bdd.Proofs;
        ObservableCollection<Proof> _listProof = new();

        public ProofViewModel()
        {
            Index();
        }

        public ObservableCollection<Proof> ListProof
        {
            get
            {
                return _listProof;
            }
            set
            {
                _listProof = value;
            }
        }

        void Index()
        {
            foreach (Proof proof in DBPROOF)
            {
                _listProof.Add(proof);
            }
        }

        public void Store(string motive, string comment = null, bool justify = false)
        {
            Proof NewProof = new() 
            {
                Motive = motive,
                Comment = comment,
                Justify = justify
            };

            DBPROOF.Add(NewProof);
            Db.Bdd.SaveChanges();
        }

        public void Update()
        {
            Db.Bdd.SaveChanges();
        }

        public void Delete(Proof proof)
        {
            DBPROOF.Remove(proof);
            Db.Bdd.SaveChanges();
        }
    }
}
