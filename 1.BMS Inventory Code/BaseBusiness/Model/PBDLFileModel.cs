
using System;
namespace BMS.Model
{
	public class PBDLFileModel : BaseModel
	{
		private int iD;
		private string folderContain;
		private string folderPath;
		private string fileName;
		private int getType;
		private string filterThongSo;
		private bool filterMaVatLieu;
		private string filterDonVi;
		private string description;
        private string extension;

        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        bool mAT;

        public bool MAT
        {
            get { return mAT; }
            set { mAT = value; }
        }
        bool tEM;

        public bool TEM
        {
            get { return tEM; }
            set { tEM = value; }
        }

        int fileType;

        public int FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string FolderContain
		{
			get { return folderContain; }
			set { folderContain = value; }
		}
	
		public string FolderPath
		{
			get { return folderPath; }
			set { folderPath = value; }
		}
	
		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}
	
		public int GetType
		{
			get { return getType; }
			set { getType = value; }
		}
	
		public string FilterThongSo
		{
			get { return filterThongSo; }
			set { filterThongSo = value; }
		}
	
		public bool FilterMaVatLieu
		{
			get { return filterMaVatLieu; }
			set { filterMaVatLieu = value; }
		}
	
		public string FilterDonVi
		{
			get { return filterDonVi; }
			set { filterDonVi = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	