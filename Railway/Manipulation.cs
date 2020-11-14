using Railway.Dao;
using Railway.Dao.Interfaces;
using Railway.Entity;
using System;
using System.Data;
using System.Data.Entity.Core;
using System.Windows.Forms;

namespace Railway {

    public partial class Manipulation : Form {

        private TrainDao trainDao                   = new TrainDaoImpl();
        private TrainTypeDao trainTypeDao           = new TrainTypeDaoImpl();
        private PersonDao personDao                 = new PersonDaoImpl();
        private RailwayTicketDao railwayTicketDao   = new RailwayTicketDaoImpl();

        private Person          mutablePersonObject;
        private Train           mutableTrainObject;
        private TrainType       mutableTrainTypeObject;
        private RailwayTicket   mutableRailwayTicket;

        public Manipulation() {
            InitializeComponent();
            InitializeListeners();
        }

        public Manipulation(string tableName, int id) : this() {
            LoadModified(tableName, id);
        }

        /// <summary>
        /// Initializing listeners
        /// </summary>
        private void InitializeListeners() {

            /*
              \ Person
             */
            findPersonButton.Click      += FindPersonButton_Click;
            changePersonButton.Click    += ChangePersonButton_Click;
            addPersonButton.Click       += AddPersonButton_Click;

            /*
             \ Train
            */
            findTrainButton.Click       += FindTrainButton_Click;
            addTrainButton.Click        += AddTrainButton_Click;
            changeTrainButton.Click     += ChangeTrainButton_Click;

            /*
             \ TrainType
             */
            addTypeButton.Click         += AddTypeButton_Click;
            changeTypeButton.Click      += ChangeTypeButton_Click;
            findTypeButton.Click        += FindTypeButton_Click;

            /*
             \ RailwatTicket
             */
            findRailwayTicketButton.Click += FindRailwayTicketButton_Click;
            addRailwayTicketButton.Click += AddRailwayTicketButton_Click;
            changeRailwayTicketButton.Click += ChangeRailwayTicketButton_Click;

            /*
             \ Another
             */

            // Loading available train types in ComboBox
            typeTrainField.Click += TypeTrainField_Click;

            // Loading available persons in ComboBox
            personField.Click += PersonField_Click;

            // Loading available trains in ComboBox
            trainField.Click += TrainField_Click;

            // Change the type of data entry for a person
            changePersonVariant.Click += ChangePersonVariant_Click;

            // Change train data entry option
            changeTrainVariant.Click += ChangeTrainVariant_Click;

            // Change train type entry option
            changeTrainTypeInputVariant.Click += ChangeTrainTypeInputVariant_Click;

            // Reset RailwayTicket search
            clearFindObject.Click += ClearFindObject_Click;

            // Reset Train search
            clearFindType.Click += ClearFindType_Click;

        }

        /*
         \ Load modified record   
         */

        private void LoadModified(string tableName, int id) {

            switch (tableName) {
                case "Люди": {
                    manipulationControl.SelectedIndex = 0;
                    OutputModifiedObject(personDao.FindById(id));
                    break;
                }
                case "Поезда": {
                    manipulationControl.SelectedIndex = 1;
                    OutputModifiedObject(trainDao.FindById(id));
                    break;
                }
                case "Типы поездов": {
                    manipulationControl.SelectedIndex = 2;
                    OutputModifiedObject(trainTypeDao.FindById(id));
                    break;
                }
                case "Железнодорожные билеты": {
                    manipulationControl.SelectedIndex = 3;
                    OutputModifiedObject(railwayTicketDao.FindById(id));
                    break;
                }
            }
        }

        /*
         \ Reset search
         */

        private void ClearFindType_Click(object sender, EventArgs e) {
            ClearFindType();
        }

        private void ClearFindObject_Click(object sender, EventArgs e) {
            ClearFindObject();
        }

        private void ClearFindObject() {
            mutableRailwayTicket = null;

            changePersonVariant.Enabled = true;
            changeTrainVariant.Enabled  = true;
        }

        private void ClearFindType() {
            mutableTrainObject = null;

            changeTrainTypeInputVariant.Enabled = true;
        }

        /*
         \ Change input variants
        */

        private void ChangePersonVariant_Click(object sender, EventArgs e) {
            ChangePersonInputVariant();
        }

        private void ChangeTrainVariant_Click(object sender, EventArgs e) {
            ChangeTrainInputVariant();
        }

        private void ChangeTrainTypeInputVariant_Click(object sender, EventArgs e) {
            ChangeTrainTypeInputVariant();
        }

        private void ChangePersonInputVariant() {
            personField.Enabled         = !changePersonVariant.Checked;
            personSelfField.Enabled     = changePersonVariant.Checked;
        }

        private void ChangeTrainInputVariant() {
            trainField.Enabled      = !changeTrainVariant.Checked;
            trainSelfField.Enabled  = changeTrainVariant.Checked;
        }

        private void ChangeTrainTypeInputVariant() {
            typeTrainField.Enabled      = !changeTrainTypeInputVariant.Checked;
            typeTrainSelfField.Enabled  = changeTrainTypeInputVariant.Checked;
        }

        /*
         \ Loading available data in ComboBox
         */

        private void TrainField_Click(object sender, EventArgs e) {
            LoadTrains();
        }

        private void PersonField_Click(object sender, EventArgs e) {
            LoadPersons();
        }

        private void TypeTrainField_Click(object sender, EventArgs e) {
            LoadTrainTypes();
        }

        private void LoadTrainTypes() {
            typeTrainField.DataSource = trainTypeDao.FindAllNames();
        }

        private void LoadTrains() {
            trainField.DataSource = trainDao.FindAllModels();
        }

        private void LoadPersons() {
            personField.DataSource = personDao.FindAllPersons();
        }

        /*
         \ RailwayTicket
         */

        private void ChangeRailwayTicketButton_Click(object sender, EventArgs e) {
            try {
                ChangeRailwayTicket();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void FindRailwayTicketButton_Click(object sender, EventArgs e) {
            try {
                FindRailwayTicket();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRailwayTicketButton_Click(object sender, EventArgs e) {
            try {
                AddRailwayTicket();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRailwayTicket() {
            RailwayTicket railwayTicket;

            try {

                string personPassportData, trainModel;

                personPassportData  = changePersonVariant.Checked ? personSelfField.Text : personField.Text;
                trainModel          = changeTrainVariant.Checked ? trainSelfField.Text : trainField.Text;

                railwayTicket = new RailwayTicket {
                    PersonId = personDao.FindByPassportData(
                            personPassportData.Split(' ')[0],
                            personPassportData.Split(' ')[1]
                        ).Id,
                    TrainId = trainDao.FindByModel(trainModel).Id,
                    PointOfDeparture = pointOfDepartureField.Text,
                    PointOfArrival = pointOfArrivalField.Text,
                    DepartureTime = DateTime.Parse(departureTimeField.Text),
                    ArrivalTime = DateTime.Parse(arrivalTimeField.Text),
                    CarriageNumber = Convert.ToInt32(carriageNumberField.Text),
                    SeatOfCarriage = Convert.ToInt32(seatOfCarriageField.Text),
                    TicketPrice = Convert.ToDecimal(ticketPriceField.Text)
                };
            } catch (FormatException) {
                MessageBox.Show("Неправильные данные!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } catch (IndexOutOfRangeException) {
                MessageBox.Show("Неправильные данные!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } catch (ObjectNotFoundException exception) {
                MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                railwayTicketDao.Add(railwayTicket);
            } catch (DataException exception) {
                MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Билет успешно добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeRailwayTicket() {

            if (mutableRailwayTicket == null) {
                MessageBox.Show("Сначала воспользуйтесь поиском!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                mutableRailwayTicket.PersonId           = personDao.FindByPassportData(
                        personSelfField.Text.Split(' ')[0],
                        personSelfField.Text.Split(' ')[1]
                    ).Id;
                mutableRailwayTicket.TrainId            = trainDao.FindByModel(trainSelfField.Text).Id;
                mutableRailwayTicket.PointOfDeparture   = pointOfDepartureField.Text;
                mutableRailwayTicket.PointOfArrival     = pointOfArrivalField.Text;
                mutableRailwayTicket.DepartureTime      = DateTime.Parse(departureTimeField.Text);
                mutableRailwayTicket.ArrivalTime        = DateTime.Parse(arrivalTimeField.Text);
                mutableRailwayTicket.CarriageNumber     = Convert.ToInt32(carriageNumberField.Text);
                mutableRailwayTicket.SeatOfCarriage     = Convert.ToInt32(seatOfCarriageField.Text);
                mutableRailwayTicket.TicketPrice        = Convert.ToDecimal(ticketPriceField.Text);
            } catch (FormatException) {
                MessageBox.Show("Неправильные данные!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            railwayTicketDao.Merge(mutableRailwayTicket);

            mutableRailwayTicket = null;

            changePersonVariant.Enabled = true;
            changeTrainVariant.Enabled  = true;

            MessageBox.Show("Изменение выполнено успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindRailwayTicket() {
            RailwayTicket railwayTicket;

            try {
                railwayTicket = railwayTicketDao.FindBySeatInTrain(
                    Convert.ToInt32(seatInTrain.Text.Split('-')[0]),
                    Convert.ToInt32(seatInTrain.Text.Split('-')[1])
                );
            } catch (ObjectNotFoundException) {
                MessageBox.Show("Данное место свободно!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mutableRailwayTicket = null;
                return;
            } catch (FormatException) {
                MessageBox.Show("Неправильный формат ввода!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mutableRailwayTicket = null;
                return;
            }

            changePersonVariant.Checked = true;
            changeTrainVariant.Checked  = true;

            ChangePersonInputVariant();
            ChangeTrainInputVariant();

            personSelfField.Text            = personDao.FindById(railwayTicket.PersonId).FullPassport;
            trainSelfField.Text             = trainDao.FindById(railwayTicket.TrainId).Model;
            pointOfDepartureField.Text      = railwayTicket.PointOfDeparture;
            pointOfArrivalField.Text        = railwayTicket.PointOfArrival;
            departureTimeField.Text         = railwayTicket.DepartureTime.ToString();
            arrivalTimeField.Text           = railwayTicket.ArrivalTime.ToString();
            carriageNumberField.Text        = railwayTicket.CarriageNumber.ToString();
            seatOfCarriageField.Text        = railwayTicket.SeatOfCarriage.ToString();
            ticketPriceField.Text           = railwayTicket.TicketPrice.ToString();

            mutableRailwayTicket            = railwayTicket;

            changePersonVariant.Enabled = false;
            changeTrainVariant.Enabled  = false;

            MessageBox.Show("Поиск выполнен успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Outputting an object to be modified selected in a different form
        /// </summary>
        /// <param name="train">Pre-found object</param>
        private void OutputModifiedObject(RailwayTicket railwayTicket) {

            changePersonVariant.Checked = true;
            changeTrainVariant.Checked = true;

            ChangePersonInputVariant();
            ChangeTrainInputVariant();

            personSelfField.Text            = personDao.FindById(railwayTicket.PersonId).FullPassport;
            trainSelfField.Text             = trainDao.FindById(railwayTicket.TrainId).Model;
            pointOfDepartureField.Text      = railwayTicket.PointOfDeparture;
            pointOfArrivalField.Text        = railwayTicket.PointOfArrival;
            departureTimeField.Text         = railwayTicket.DepartureTime.ToString();
            arrivalTimeField.Text           = railwayTicket.ArrivalTime.ToString();
            carriageNumberField.Text        = railwayTicket.CarriageNumber.ToString();
            seatOfCarriageField.Text        = railwayTicket.SeatOfCarriage.ToString();
            ticketPriceField.Text           = railwayTicket.TicketPrice.ToString();

            mutableRailwayTicket            = railwayTicket;

            changePersonVariant.Enabled     = false;
            changeTrainVariant.Enabled      = false;
        }

        /*
         \ TrainType
         */

        private void AddTypeButton_Click(object sender, EventArgs e) {
            try {
                AddType();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindTypeButton_Click(object sender, EventArgs e) {
            try {
                FindType();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeTypeButton_Click(object sender, EventArgs e) {
            try {
                ChangeType();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddType() {
            TrainType trainType;

            trainType = new TrainType {
                Name = nameField.Text
            };

            try {
                trainTypeDao.Add(trainType);
            } catch (DataException) {
                MessageBox.Show("Неверные данные!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Тип поезда успешно добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeType() {

            if (mutableTrainTypeObject == null) {
                MessageBox.Show("Сначала воспользуйтесь поиском!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                mutableTrainTypeObject.Name = nameField.Text;
            } catch (FormatException) {
                MessageBox.Show("Неправильные данные!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            trainTypeDao.Merge(mutableTrainTypeObject);

            mutableTrainTypeObject = null;

            MessageBox.Show("Изменение выполнено успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindType() {
            TrainType trainType;

            try {
                trainType = trainTypeDao.FindByName(
                    nameDataField.Text
                );
            } catch (ObjectNotFoundException) {
                MessageBox.Show("Поезда такого типа не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mutableTrainTypeObject = null;
                return;
            }

            nameField.Text          = trainType.Name;

            mutableTrainTypeObject  = trainType;

            MessageBox.Show("Поиск выполнен успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Outputting an object to be modified selected in a different form
        /// </summary>
        /// <param name="train">Pre-found object</param>
        private void OutputModifiedObject(TrainType type) {

            nameField.Text          = type.Name;

            mutableTrainTypeObject  = type;
        }

        /*
         \ Train
         */

        private void AddTrainButton_Click(object sender, EventArgs e) {
            try {
                AddTrain();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeTrainButton_Click(object sender, EventArgs e) {
            try {
                ChangeTrain();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindTrainButton_Click(object sender, EventArgs e) {
            try {
                FindTrain();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTrain() {
            Train train;

            string trainType = changeTrainTypeInputVariant.Checked ? typeTrainSelfField.Text : typeTrainField.Text;

            try {
                train = new Train {
                    TypeId              = trainTypeDao.FindByName(trainType).Id,
                    Model               = modelField.Text,
                    MaxSpeed            = Convert.ToDecimal(maxSpeedField.Text),
                    AmountSeat          = Convert.ToInt32(amountSeatField.Text),
                    ManufacturerCountry = manufacturerCountryField.Text
                };
            } catch (FormatException) {
                MessageBox.Show("Неправильные данные!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } catch (ObjectNotFoundException exception) {
                MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                trainDao.Add(train);
            } catch (DataException exception) {
                MessageBox.Show(exception.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Поезд успешно добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeTrain() {

            if (mutableTrainObject == null) {
                MessageBox.Show("Сначала воспользуйтесь поиском!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try {
                mutableTrainObject.TypeId               = trainTypeDao.FindByName(typeTrainSelfField.Text).Id;
                mutableTrainObject.Model                = modelField.Text;
                mutableTrainObject.MaxSpeed             = Convert.ToDecimal(maxSpeedField.Text);
                mutableTrainObject.AmountSeat           = Convert.ToInt32(amountSeatField.Text);
                mutableTrainObject.ManufacturerCountry  = manufacturerCountryField.Text;
            } catch (FormatException) {
                MessageBox.Show("Неправильные данные!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } catch (ObjectNotFoundException excepion) {
                MessageBox.Show(excepion.Message, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            trainDao.Merge(mutableTrainObject);

            mutableTrainObject = null;

            changeTrainTypeInputVariant.Enabled = true;

            MessageBox.Show("Изменение выполнено успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindTrain() {
            Train train;

            try {
                train = trainDao.FindByModel(
                    modelDataField.Text
                );
            } catch (ObjectNotFoundException) {
                MessageBox.Show("Поезда такой модели не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mutableTrainObject = null;
                return;
            }

            typeTrainSelfField.Text         = trainTypeDao.FindById(train.TypeId).Name;
            modelField.Text                 = train.Model;
            maxSpeedField.Text              = train.MaxSpeed.ToString();
            amountSeatField.Text            = train.AmountSeat.ToString();
            manufacturerCountryField.Text   = train.ManufacturerCountry;

            mutableTrainObject              = train;

            changeTrainTypeInputVariant.Checked = true;
            changeTrainTypeInputVariant.Enabled = false;
            ChangeTrainTypeInputVariant();

            MessageBox.Show("Поиск выполнен успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Outputting an object to be modified selected in a different form
        /// </summary>
        /// <param name="train">Pre-found object</param>
        private void OutputModifiedObject(Train train) {

            typeTrainSelfField.Text         = trainTypeDao.FindById(train.TypeId).Name;
            modelField.Text                 = train.Model;
            maxSpeedField.Text              = train.MaxSpeed.ToString();
            amountSeatField.Text            = train.AmountSeat.ToString();
            manufacturerCountryField.Text   = train.ManufacturerCountry;

            mutableTrainObject              = train;

            changeTrainTypeInputVariant.Checked = true;
            changeTrainTypeInputVariant.Enabled = false;
            ChangeTrainTypeInputVariant();
        }

        /*
         \ Person
         */

        private void AddPersonButton_Click(object sender, EventArgs e) {
            try {
                AddPerson();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangePersonButton_Click(object sender, EventArgs e) {
            try {
                ChangePerson();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindPersonButton_Click(object sender, EventArgs e) {
            try {
                FindPerson();
            } catch (DataException) {
                MessageBox.Show("У вас нет прав на совершение этого действия", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPerson() {

            Person person = new Person {
                PassportSeries  = passportSeriesField.Text,
                PassportId      = passportIdField.Text,
                SecondName      = secondNameField.Text,
                FirstName       = firstNameField.Text,
                MiddleName      = middleNameField.Text
            };

            try {
                personDao.Add(person);
            } catch (DataException) {
                MessageBox.Show("Неверные данные!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Человек успешно добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangePerson() {

            if (mutablePersonObject == null) {
                MessageBox.Show("Сначала воспользуйтесь поиском!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            mutablePersonObject.PassportId      = passportIdField.Text;
            mutablePersonObject.PassportSeries  = passportSeriesField.Text;
            mutablePersonObject.SecondName      = secondNameField.Text;
            mutablePersonObject.FirstName       = firstNameField.Text;
            mutablePersonObject.MiddleName      = middleNameField.Text;

            personDao.Merge(mutablePersonObject);

            mutablePersonObject = null;

            MessageBox.Show("Изменение выполнено успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindPerson() {
            Person person;

            try {
                person = personDao.FindByPassportData(
                    passportDataField.Text.Split(' ')[0],
                    passportDataField.Text.Split(' ')[1]
                );
            } catch (ObjectNotFoundException) {
                MessageBox.Show("Человека с такими паспортными данными не существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                mutablePersonObject = null;
                return;
            }

            passportIdField.Text        = person.PassportId;
            passportSeriesField.Text    = person.PassportSeries;
            secondNameField.Text        = person.SecondName;
            firstNameField.Text         = person.FirstName;
            middleNameField.Text        = person.MiddleName;

            mutablePersonObject         = person;

            MessageBox.Show("Поиск выполнен успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Outputting an object to be modified selected in a different form
        /// </summary>
        /// <param name="train">Pre-found object</param>
        private void OutputModifiedObject(Person person) {

            passportIdField.Text        = person.PassportId;
            passportSeriesField.Text    = person.PassportSeries;
            secondNameField.Text        = person.SecondName;
            firstNameField.Text         = person.FirstName;
            middleNameField.Text        = person.MiddleName;

            mutablePersonObject         = person;
        }

    }
}
