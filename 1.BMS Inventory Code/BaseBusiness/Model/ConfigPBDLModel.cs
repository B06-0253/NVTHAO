
using System;
namespace BMS.Model
{
	public class ConfigPBDLModel : BaseModel
	{
		private int iD;
		private string folderContain;
		private string folderPath;
		private string fileName;
		private int getType;
		private string filterThongSo;
		private bool filterMaVatLieu;
		private string filterDonVi;
		private string department;
		private int departmentIndex;
		private string description;
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
	
		public string Department
		{
			get { return department; }
			set { department = value; }
		}
	
		public int DepartmentIndex
		{
			get { return departmentIndex; }
			set { departmentIndex = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	