using System.Windows.Input;
using Prism.Regions;
using Prism.Mvvm;
using Legacy.Models;
using System.Collections.ObjectModel;
using Legacy.Library;
using Unity;
using Prism.Events;
using Prism.Commands;
using System;
using System.Windows;
using Library;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls.Primitives;
using Prism.Interactivity;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Commands;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace Legacy.WPFRegionalManager.ViewModels
{
	public class UserMaintainerViewModel : BindableBase
    {
		private string _userFullName;
		private int jobTitle;
		private int departmentid;
		private bool _newUser;
		public string User_Full_Name
		{
			get { return _userFullName; }
			set { _userFullName = value; RaisePropertyChanged("User_Full_Name"); }
		}

		private string _user_Active_YN;
		public string User_Active_YN
		{
			get { return _user_Active_YN; }
			set { _user_Active_YN = value; RaisePropertyChanged("User_Active_YN"); }
		}

		private string s_UserName;
		public string User_Name
		{
			get { return s_UserName; }
			set { s_UserName = value; RaisePropertyChanged("User_Name"); }
		}

		private string s_phoneno;
		public string User_Phone
		{
			get { return s_phoneno; }
			set { s_phoneno = value; RaisePropertyChanged("User_Phone"); }
		}

		private string _User_Fax;
		public string User_Fax
		{
			get { return _User_Fax; }
			set { _User_Fax = value; RaisePropertyChanged("User_Fax"); }
		}

		private DateTime _DATE_OF_BIRTH;
		public DateTime DATE_OF_BIRTH
		{
			get { return _DATE_OF_BIRTH; }
			set { _DATE_OF_BIRTH = value; RaisePropertyChanged("DATE_OF_BIRTH"); }
		}


		private string _User_Email;
		public string User_Email
		{
			get { return _User_Email; }
			set { _User_Email = value; RaisePropertyChanged("User_Email"); }
		}

		private string _SIGNATURE_PATH;
		public string SIGNATURE_PATH
		{
			get { return _SIGNATURE_PATH; }
			set { _SIGNATURE_PATH = value; RaisePropertyChanged("SIGNATURE_PATH"); }
		}

		private int _JOB_TITLE_ID;
		public int JOB_TITLE_ID
		{
			get { return _JOB_TITLE_ID; }
			set { _JOB_TITLE_ID = value; RaisePropertyChanged("JOB_TITLE_ID"); }
		}

		private int _DEPARTMENT_ID;
		public int DEPARTMENT_ID
		{
			get { return _DEPARTMENT_ID; }
			set { _DEPARTMENT_ID = value; RaisePropertyChanged("DEPARTMENT_ID"); }
		}

		public ICommand ProductSelected { get; set; }
		public ICommand ProductRightSelected { get; set; }

		private UserModel _selectedUser;
		public UserModel SelectedUser
		{
			get { return _selectedUser; }
			set
			{
				_selectedUser = value;
				if (value != null && !string.IsNullOrWhiteSpace(value.User_Name))
				{
					CommonFunctions commonFunctions = new CommonFunctions();

					var userInfo = commonFunctions.GetUserDetails(SelectedUser.User_Name);
					if (userInfo !=null )
					{
						User_Full_Name = userInfo.User_Full_Name;
						User_Name = userInfo.User_Name;
						User_Name = userInfo.User_Name;
						User_Phone = userInfo.User_Phone;
						User_Email = userInfo.User_Email;
						User_Fax = userInfo.User_Fax;
						DEPARTMENT_ID = userInfo.DEPARTMENT_ID;
						DATE_OF_BIRTH = userInfo.DATE_OF_BIRTH;
						SelectedJobTitleId = userInfo.JOB_TITLE_ID;
						SelectedDepartmentId = userInfo.DEPARTMENT_ID;
						User_Active_YN = userInfo.User_Active_YN;
						UserAccountActive = userInfo.User_Active_YN == "Y" ? true : false;
						_newUser = false;
					}
				}
				RaisePropertyChanged("SelectedUser");
			}
		}

		private DepartmentModel _selectedDepartment;
		public DepartmentModel SelectedDepartment
		{
			get { return _selectedDepartment; }
			set
			{
				_selectedDepartment = value;
				if (value != null)
				{
					CommonFunctions commonFunctions = new CommonFunctions();

					var departments = commonFunctions.GetDepartmentUsers(_selectedDepartment.DEPARTMENT_ID);
					PaginationUserList = new ObservableCollection<UserModel>(departments);

					SourceCollection = new ObservableCollection<UserModel>(departments);
				}
				RaisePropertyChanged("PaginationUserList");
			}
		}

		private JobTitleModel _selectedJobTitle;
		public JobTitleModel SelectedJobTitle
		{
			get { return _selectedJobTitle; }
			set
			{
				_selectedJobTitle = value;
				RaisePropertyChanged("SelectedJobTitle");
			}
		}

		private int selectedSource;
		public int SelectedSource
		{
			get { return selectedSource; }
			set
			{
				selectedSource = value;
				RaisePropertyChanged("SelectedSource");
			}
		}

		private int selectedDepartmentId;
		public int SelectedDepartmentId
		{
			get { return selectedDepartmentId; }
			set
			{
				selectedDepartmentId = value;
				RaisePropertyChanged("SelectedDepartmentId");
			}
		}

		public bool userAccountActive;
		public bool UserAccountActive
		{
			get { return userAccountActive; }
			set
			{
				userAccountActive = value;
				if (userAccountActive)
					User_Active_YN = "Y";
				else
					User_Active_YN = "N";
				RaisePropertyChanged("UserAccountActive");
			}
		}

		private int selectedJobTitleId;
		public int SelectedJobTitleId
		{
			get { return selectedJobTitleId; }
			set
			{
				selectedJobTitleId = value;
				RaisePropertyChanged("SelectedJobTitleId");
			}
		}

		private DisplayItem DisplayItemFor(UserModel user)
		{
			return new DisplayItem(user.User_Name , user);
		}

		private ObservableCollection<UserModel> sourceCollection;
		public ObservableCollection<UserModel> SourceCollection
		{
			get { return sourceCollection; }
			set
			{
				sourceCollection = value;
				RaisePropertyChanged("SourceCollection");
			}
		}

		private ObservableCollection<UserModel> userList;
		public ObservableCollection<UserModel> PaginationUserList
		{
			get { return userList; }
			set
			{
				if (userList != value)
					userList = value;
				RaisePropertyChanged("PaginationUserList");
			}
		}

		private ObservableCollection<DepartmentModel> departmentList;
		public ObservableCollection<DepartmentModel> DepartmentList
		{
			get { return departmentList; }
			set
			{
				if (departmentList != value)
					departmentList = value;
				RaisePropertyChanged("DepartmentList");
			}
		}

		private ObservableCollection<JobTitleModel> jobtitleList;
		public ObservableCollection<JobTitleModel> JobTitleList
		{
			get { return jobtitleList; }
			set
			{
				if (jobtitleList != value)
					jobtitleList = value;
				RaisePropertyChanged("JobTitleList");
			}
		}

		private ObservableCollection<RoleModel> rolelist;
		public ObservableCollection<RoleModel> RoleList
		{
			get { return rolelist; }
			set
			{
				if (rolelist != value)
					rolelist = value;
				RaisePropertyChanged("RoleList");
			}
		}

		public ICommand SaveCommand;


		private ICommand _addUserCommand;
		public ICommand AddUserCommand
		{
			get { return _addUserCommand; }
			set
			{
				_addUserCommand = value;
				_newUser = true;
				RaisePropertyChanged("AddUserCommand");
			}
		}

		private ICommand _saveUserRoleCommand;
		public ICommand SaveUserRoleCommand
		{
			get { return _saveUserRoleCommand; }
			set
			{
				_saveUserRoleCommand = value;
				RaisePropertyChanged("		SaveUserRoleCommand");
			}
		}

		private ICommand _saveUserCommand;
		public ICommand SaveUserCommand
		{
			get { return _saveUserCommand; }
			set
			{
				_saveUserCommand = value;
				RaisePropertyChanged("SaveUserCommand");
			}
		}

		private ICommand _clearUserCommand;
		public ICommand ClearUserCommand
		{
			get { return _clearUserCommand; }
			set
			{
				_clearUserCommand = value;
				RaisePropertyChanged("ClearUserCommand");
			}
		}

		private ICommand _deactivateUserCommand;
		public ICommand DeactivateUserCommand
		{
			get { return _deactivateUserCommand; }
			set
			{
				_deactivateUserCommand = value;
				RaisePropertyChanged("DeactivateUserCommand");
			}
		}

		private IEventAggregator _eventArg;
		private IRegionManager _regionManager;
		private IUnityContainer _container;

		public UserMaintainerViewModel(IRegionManager regionManager, IUnityContainer container, IEventAggregator eventArg)
		{
			_eventArg = eventArg;
			_regionManager = regionManager;
			_container = container;
			
			AddUserCommand = new DelegateCommand(AddUser, Cleared);
			SaveUserCommand = new DelegateCommand(SaveUser, canSaveUser).ObservesProperty(() => User_Name ).ObservesProperty(() => User_Full_Name).ObservesProperty(() => User_Email).ObservesProperty(() => SelectedDepartment).ObservesProperty(() => SelectedJobTitle);
			DeactivateUserCommand = new DelegateCommand(DeActivatedUser, canDeActivateCleared);
			SaveUserRoleCommand = new DelegateCommand(saveUserRole, canSaveUserRole);
			PopulateLists();
			clearFields();
		}
		bool Cleared()
		{
			return true;
		}

		private bool canSaveUserRole()
		{
			return true;
		}
		private void saveUserRole()
		{ 

		}

		private void DeActivatedUser()
		{
			DeActivateUser();
		}

		bool canDeActivateCleared()
		{
			return true;
			if (!string.IsNullOrWhiteSpace(User_Name))
			{
				return true;
			}
			return false;
		}

		private bool canSaveUser()
		{
			if (string.IsNullOrWhiteSpace(User_Name) || string.IsNullOrWhiteSpace(User_Full_Name) || string.IsNullOrWhiteSpace(User_Email)) 
			{
				return false;
			}
			
			return true;
		}

		void editUserDetails()
		{
			jobTitle = 0;
			departmentid = 0;
			if (SelectedJobTitle != null)
				jobTitle = SelectedJobTitle.JOB_TITLE_ID;
			
			if (SelectedDepartment != null)
				departmentid = SelectedDepartment.DEPARTMENT_ID;

			User user = new User();
			_ = user.UpdateUser(new UserModel
			{
				DATE_OF_BIRTH = DATE_OF_BIRTH,
				User_Email = User_Email,
				User_Full_Name = User_Full_Name,
				User_Phone = User_Phone,
				User_Active_YN = User_Active_YN,
				User_Name = User_Name,
				JOB_TITLE_ID = jobTitle,
				DEPARTMENT_ID = departmentid,
				SIGNATURE_PATH = ""
			});
			System.Windows.MessageBox.Show("Successfully Updated", "User Details Updated", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		void addUserDetails()
		{
			jobTitle = 0;
			departmentid = 0;

			if (SelectedDepartment == null)
			{
				System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Please select user Department", "Department not selected", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			departmentid = SelectedDepartment.DEPARTMENT_ID;

			if (SelectedJobTitle == null)
			{
				System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Please select user Job Title", "Job Title not selected", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			jobTitle = SelectedJobTitle.JOB_TITLE_ID;


			User user = new User();
			user.AddUser(new UserModel
			{
				DATE_OF_BIRTH = DATE_OF_BIRTH,
				User_Email = User_Email,
				User_Full_Name = User_Full_Name,
				User_Phone = User_Phone,
				User_Active_YN = User_Active_YN,
				User_Name = User_Name,
				JOB_TITLE_ID = jobTitle,
				DEPARTMENT_ID = departmentid,
				SIGNATURE_PATH = ""
			});
			System.Windows.MessageBox.Show("Successfully Saved", "User Details Added", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		void DeActivateUser()
		{
			if (!string.IsNullOrWhiteSpace(User_Name))
			{
				System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Continue with de-activating access for : {User_Full_Name }", "User De-Activation", MessageBoxButton.YesNo, MessageBoxImage.Question);
				if (messageBoxResult == MessageBoxResult.Yes)
				{
					User user = new User();
					_ = user.DeActivateUser(User_Name);
					System.Windows.MessageBox.Show("Successfully De-Activated", "User De-Activated", MessageBoxButton.OK, MessageBoxImage.Information);
				}
			}
			else
			{
				System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Please select user to de-activate", "User De-Activation", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void SaveUser()
		{
			if (string.IsNullOrWhiteSpace(User_Active_YN))
				User_Active_YN = "N";
			
			if (!_newUser)
			{
				editUserDetails();
			}
			else
			{
				addUserDetails();
				CommonFunctions commFuncs = new CommonFunctions();
				var unfilteredList = commFuncs.GetAllUsers();
				SourceCollection = new ObservableCollection<UserModel>(unfilteredList);
				SelectedSource = -1;
				_newUser = false;
			}
		}

		void clearFields()
		{
			User_Email = "";
			User_Full_Name = "";
			User_Phone = "";
			User_Active_YN = "";
			User_Name = "";
			SelectedJobTitleId = -1;
			SelectedDepartmentId = -1;
			selectedSource = -1;
			SelectedUser = null;
			User_Phone = "";
			User_Fax = "";
			UserAccountActive = false;
		}
		private void AddUser()
		{
			_newUser = true;
			clearFields();
		}

		private void PopulateLists()
		{
			CommonFunctions commFuncs = new CommonFunctions();
			var unfilteredList = commFuncs.GetAllUsers();
			PaginationUserList = new ObservableCollection<UserModel>(unfilteredList);
			
			var departments = commFuncs.GetAllDepartments();
			DepartmentList = new ObservableCollection<DepartmentModel>(departments);

			var jobtitles = commFuncs.GetAllJobTitles();
			JobTitleList = new ObservableCollection<JobTitleModel>(jobtitles);

			var roleslist = commFuncs.GetAllRoles();
			RoleList = new ObservableCollection<RoleModel>(roleslist);
			clearFields();
		}

		private void GetAllUsers()
		{
			
		}
	}
}
