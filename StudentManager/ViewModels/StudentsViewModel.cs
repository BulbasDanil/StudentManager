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
            Students = new List<Student>();

            Students.Add(new Student() { Id = 999, Name = "Students" });

            var StudentList = _dataManager.Students.ToList();
            foreach (Student student in StudentList)
            {
                Students.Add(student);
            }
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
                      Id = 0,
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
                        var studentsToSave = Students.Where(s => s.Id == 0).ToList();
                        foreach (var student in studentsToSave)
                        {
                            _dataManager.Students.Add(student);
                        }
                        _dataManager.SaveChanges();
                    }));
            }
        }

        private RelayCommand _removeStudentCommand;
        public RelayCommand RemoveStudentCommand
        {
            get
            {
                return _removeStudentCommand ?? (_removeStudentCommand = new RelayCommand(obj =>
                {
                    _dataManager.Students.Remove(SelectedStudent);
                    _dataManager.SaveChanges();
                }
                  ));
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
