using StudentManager.Commands;
using StudentManager.EDM;
using StudentManager.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace StudentManager.ViewModels
{
    public class StudentsViewModel : INotifyPropertyChanged
    {
        private DataManager _dataManager;
        public List<Student> Students { get; set; }

        private Student _selectedStudent { get; set; }
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        public StudentsViewModel()
        {
            _dataManager = new DataManager();
            Students = _dataManager.Students.ToList();
        }

        // CRUD Commands
        private RelayCommand _addStudentCommand;
        public RelayCommand AddStudentCommand
        {
            get
            {
                return _addStudentCommand ??
                (_addStudentCommand = new RelayCommand(obj =>
              {
                  Student student = new Student()
                  {
                      Name = "",
                      Surname = "",
                      BirthDate = new System.DateTime(),
                      EnrollmentYear = new System.DateTime(),
                      Phone = "",
                      Email = "",
                      Adress = "",
                      GroupId = 0,
                      IsElder = false,

                  };
                  Students.Add(student);
                  _dataManager.SaveChanges();
                  SelectedStudent = student;
              }));
            }
        }

        private RelayCommand _saveStudentCommand;
        public RelayCommand SaveStudentCommand
        {
            get
            {
                return _saveStudentCommand ??
                    (_saveStudentCommand = new RelayCommand(obj =>
                    {

                    }));
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
