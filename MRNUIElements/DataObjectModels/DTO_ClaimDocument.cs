using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
using MRNNexus_Model;
using MRNUIElements.Controllers;

namespace MRNUIElements.DataObjectModels
{
    [KnownType(typeof(DTO_Base))]

    public class ClaimDocument : DTO_ClaimDocument, INotifyPropertyChanged
    {
        private int _DocumentID;
        public int DocumentID
        {
            get { return _DocumentID; }
            set
            {
                if (value != _DocumentID)
                {
                    _DocumentID = value;
                    OnPropertyChanged("DocumentID");
                }
            }
        }
        private int _ClaimID;
        public int ClaimID
        {
            get { return _ClaimID; }
            set
            {
                if (value != _ClaimID)
                {
                    _ClaimID = value;
                    OnPropertyChanged("ClaimID");
                }
            }
        }
        private string _FilePath;
        public string FilePath
        {
            get { return _FilePath; }
            set
            {
                if (value != _FilePath)
                {
                    _FilePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }
        private string _FileName;
        public string FileName
        {
            get { return _FileName; }
            set
            {
                if (value != _FileName)
                {
                    _FileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }
        private string _FileBytes;
        public string FileBytes
        {
            get { return _FileBytes; }
            set
            {
                if (value != _FileBytes)
                {
                    _FileBytes = value;
                    OnPropertyChanged("FileBytes");
                }
            }
        }

        private string _FileExt;
        public string FileExt
        {
            get { return _FileExt; }
            set
            {
                if (value != _FileExt)
                {
                    _FileExt = value;
                    OnPropertyChanged("FileExt");
                }
            }
        }
        private int _DocTypeID;
        public int DocTypeID
        {
            get { return _DocTypeID; }
            set
            {
                if (value != _DocTypeID)
                {
                    _DocTypeID = value;
                    OnPropertyChanged("DocTypeID");
                }
            }
        }


        private DateTime _DocumentDate;
        public DateTime DocumentDate
        {
            get { return _DocumentDate; }
            set
            {
                if (value != _DocumentDate)
                {
                    _DocumentDate = value;
                    OnPropertyChanged("DocumentDate");
                }
            }
        }

        private string _SignatureImagePath;
        public string SignatureImagePath
        {
            get { return _SignatureImagePath; }
            set
            {
                if (value != _SignatureImagePath)
                {
                    _SignatureImagePath = value;
                    OnPropertyChanged("SignatureImagePath");
                }
            }
        }
        private int? _NumSignatures;
        public int? NumSignatures
        {
            get { return _NumSignatures; }
            set
            {
                if (value != _NumSignatures)
                {
                    _NumSignatures = value;
                    OnPropertyChanged("NumSignatures");
                }
            }
        }
        private string _InitialImagePath;
        public string InitialImagePath
        {
            get { return _InitialImagePath; }
            set
            {
                if (value != _InitialImagePath)
                {
                    _InitialImagePath = value;
                    OnPropertyChanged("InitialImagePath");
                }
            }
        }
        private int? _NumInitials;
        public int? NumInitials
        {
            get { return _NumInitials; }
            set
            {
                if (value != _NumInitials)
                {
                    _NumInitials = value;
                    OnPropertyChanged("NumInitials");
                }
            }
        }
        private string _DocumentComments;

        public event PropertyChangedEventHandler PropertyChanged;

        public string DocumentComments
        {
            get { return _DocumentComments; }
            set
            {
                if (value != _DocumentComments)
                {
                    _DocumentComments = value;
                    OnPropertyChanged("DocumentComments");
                }
            }
        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
    public class ListOfClaimDocuments : List<ClaimDocument>
    {
        ServiceLayer s = ServiceLayer.getInstance();

        async public Task<List<DTO_ClaimDocument>> ClaimDocumentsList(Claim Claim, int DocTypeID)
        {
            await s.GetClaimDocumentsByClaimID((DTO_Claim)Claim);
            return s.ClaimDocumentsList.FindAll(x => (int)x.DocTypeID == (int)DocTypeID);

        }
    }
}
