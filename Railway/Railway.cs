using Railway.Dao;
using Railway.Dao.Interfaces;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Windows.Forms;

namespace Railway {

    public partial class Railway : Form {

        private TrainDao trainDao                   = new TrainDaoImpl();
        private TrainTypeDao trainTypeDao           = new TrainTypeDaoImpl();
        private PersonDao personDao                 = new PersonDaoImpl();
        private RailwayTicketDao railwayTicketDao   = new RailwayTicketDaoImpl();

        public Railway() {
            InitializeComponent();
            InitializeListeners();
        }

        private void InitializeListeners() {

            chooseTable.SelectedValueChanged    += ChooseTable_SelectedValueChanged;


            table.CellClick                     += Table_CellClick;
            table.CellDoubleClick               += Table_CellDoubleClick;

            deleteButton.Click                  += DeleteButton_Click;
            addChangeButton.Click               += AddChangeButton_Click;

            procedureButton.Click               += ProcedureButton_Click;
            aboutProcedureButton.Click          += AboutProcedureButton_Click;
        }

        private void AboutProcedureButton_Click(object sender, EventArgs e) {
            AboutProcedure();
        }

        private void ProcedureButton_Click(object sender, EventArgs e) {
            CallProcedure();
        }

        private void Table_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {

            if (e.RowIndex == -1) { return; }
            ChangeRow();
        }

        private void AddChangeButton_Click(object sender, EventArgs e) {

            try {
                ShowManipulationForm();
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

        private void Table_CellClick(object sender, DataGridViewCellEventArgs e) {

            try {
                DeletingNumberUpdate(e);
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChooseTable_SelectedValueChanged(object sender, EventArgs e) {

            try {
                LoadTable();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CallProcedure() {

            try {
                table.DataSource = railwayTicketDao.CallProcedure("FindTicket", procedureArgument.Text.Split(' '));
                MessageBox.Show("Хранимая процедура успешно выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch {
                MessageBox.Show("Неверные аругменты для вызова хранимой процедуры", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AboutProcedure() {

            MessageBox.Show("Данная хранимая процедура выполняет поиск билетов по введенному пункту прибытия поездов!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeRow() {

            new Manipulation(chooseTable.Text, Convert.ToInt32(deletingNumber.Value)).ShowDialog();
        }

        private void LoadTable() {

            switch (chooseTable.SelectedItem) {
                case "Люди": {
                    personDao.OutputInDataSource(ref table);
                    break;
                }
                case "Поезда": {
                    trainDao.OutputInDataSource(ref table);
                    break;
                }
                case "Типы поездов": {
                    trainTypeDao.OutputInDataSource(ref table);
                    break;
                }
                case "Железнодорожные билеты": {
                    railwayTicketDao.OutputInDataSource(ref table);
                    break;
                }
            }
        }

        private void DeleteRow() {

            try {

                switch (chooseTable.SelectedItem) {
                    case "Люди": {
                        personDao.Remove(Convert.ToInt32(deletingNumber.Value));
                        break;
                    }
                    case "Поезда": {
                        trainDao.Remove(Convert.ToInt32(deletingNumber.Value));
                        break;
                    }
                    case "Типы поездов": {
                        trainTypeDao.Remove(Convert.ToInt32(deletingNumber.Value));
                        break;
                    }
                    case "Железнодорожные билеты": {
                        railwayTicketDao.Remove(Convert.ToInt32(deletingNumber.Value));
                        break;
                    }
                }


            } catch (ObjectNotFoundException) {

                MessageBox.Show("Такая запись не найдена!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Запись успешно удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTable();
        }

        private void ShowManipulationForm() {

            new Manipulation().ShowDialog();
        }

        private void DeletingNumberUpdate(DataGridViewCellEventArgs e) {

            if (e.RowIndex == -1) { return; }
            deletingNumber.Value = Convert.ToDecimal(table.Rows[e.RowIndex].Cells[0].Value);
        }

    }
}
