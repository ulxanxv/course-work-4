using System.Windows.Forms;

namespace Railway {

    public partial class Manipulation : Form {

        public Manipulation() {
            InitializeComponent();
            InitializeListener();
        }

        public Manipulation(string tableName, int id) : this() {
            LoadModified(tableName, id);
        }

        private void InitializeListener() { 
        
        }

        private void LoadModified(string tableName, int id) {
            switch (tableName) {
                case "Студенты": {
                    manipulationControl.SelectedIndex = 0;
                    // OutputModifiedObject(personDao.FindById(id));
                    break;
                }
                case "Успеваемость": {
                    manipulationControl.SelectedIndex = 1;
                    // OutputModifiedObject(trainDao.FindById(id));
                    break;
                }
                case "Дисциплины": {
                    manipulationControl.SelectedIndex = 2;
                    // OutputModifiedObject(trainTypeDao.FindById(id));
                    break;
                }
            }
        }

    }
}
