using Railway.Dao;
using Railway.Dao.Impl;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Windows.Forms;

namespace Railway {

    public partial class SGroup : Form {

        private DisciplineDao disciplineRepository                  = new DisciplineDaoImpl();
        private StudentDao studentRepository                        = new StudentDaoImpl();
        private StudentPerformanceDao studentPerformanceRepository  = new StudentPerformanceDaoImpl();

        public SGroup() {
            InitializeComponent();
            InitializeListener();
        }

        private void InitializeListener() {
            manipulationButton.Click            += ManipulationButton_Click;
            chooseTable.SelectedValueChanged    += ChooseTable_SelectedValueChanged;

            table.CellClick                     += Table_CellClick;
            table.CellDoubleClick               += Table_CellDoubleClick;

            deleteButton.Click                  += DeleteButton_Click;
        }

        private void DeleteRow() {
            try {
                switch (chooseTable.SelectedItem) {
                    case "Студенты": {
                        studentRepository.Remove(Convert.ToInt32(deletedValue.Value));
                        break;
                    }
                    case "Успеваемость": {
                        studentPerformanceRepository.Remove(Convert.ToInt32(deletedValue.Value));
                        break;
                    }
                    case "Дисциплины": {
                        disciplineRepository.Remove(Convert.ToInt32(deletedValue.Value));
                        break;
                    }
                    default: {
                        MessageBox.Show("Таблица не выбрана!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            } catch (ObjectNotFoundException) {
                MessageBox.Show("Такая запись не найдена!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Запись успешно удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTable();
        }

        private void LoadTable() {
            switch (chooseTable.SelectedItem) {
                case "Студенты": {
                    studentRepository.OutputInDataSource(ref table);
                    break;
                }
                case "Успеваемость": {
                    studentPerformanceRepository.OutputInDataSource(ref table);
                    break;
                }
                case "Дисциплины": {
                    disciplineRepository.OutputInDataSource(ref table);
                    break;
                }
            }
        }

        private void DeletingNumberUpdate(DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1) {
                return;
            }
            deletedValue.Value = Convert.ToDecimal(table.Rows[e.RowIndex].Cells[0].Value);
        }

        private void ShowManipulationForm() {
            new Manipulation().ShowDialog();
        }

        private void ChangeRow() {
            new Manipulation(chooseTable.Text, Convert.ToInt32(deletedValue.Value)).ShowDialog();
        }

        private void ManipulationButton_Click(object sender, System.EventArgs e) {
            try {
                ShowManipulationForm();
            } catch {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChooseTable_SelectedValueChanged(object sender, System.EventArgs e) {
            try {
                LoadTable();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex == -1) {
                return;
            }
            ChangeRow();
        }

        private void Table_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                DeletingNumberUpdate(e);
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            try {
                DeleteRow();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
