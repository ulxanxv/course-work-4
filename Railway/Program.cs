using System;
using System.Data;
using System.Windows.Forms;

namespace Railway {

    static class Program {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MyApplicationContext(() => new Authorization()));
        }

        public class MyApplicationContext : System.Windows.Forms.ApplicationContext {

            public MyApplicationContext(Func<Form> formFactory) {
                Form startupForm = formFactory();
                startupForm.FormClosed += OnFormClosed;
                startupForm.Show();
            }

            private void OnFormClosed(object sender, FormClosedEventArgs e) {
                if (Application.OpenForms.Count > 0) {
                    foreach (Form form in Application.OpenForms) {
                        form.FormClosed -= OnFormClosed;
                        form.FormClosed += OnFormClosed;
                    }
                } else ExitThread();
            }
        }
    }
}
