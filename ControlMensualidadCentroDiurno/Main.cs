using ControlMensualidadCentroDiurno.database;
using ControlMensualidadCentroDiurno.domain;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using ControlMensualidadCentroDiurno.Properties;



namespace ControlMensualidadCentroDiurno
{
    public partial class MainForm : Form
    {

        static int monthlyPaymentPrice = 6000;

        int totalMonthlyPayments = 0;

        DataTable dataTableSenores;

        DBHelperSenor dBHelperSenor;

        DBHelperPayment dBHelperPayment;

        List<Senor> listAllSenores;

        List<Senor> wantedSenores;

        CultureInfo currentCulture;

        List<Panel> listPanels;

        List<Payment> listPaymentsThisMonth;

        private bool sortAscending = false;

        public MainForm()
        {

            InitializeComponent();

            listPanels = new List<Panel>();

            listPanels.Add(payments_panel);
            listPanels.Add(management_panel);
            listPanels.Add(dataGridView_panel);

            listPanels[0].BringToFront();

            currentCulture = Thread.CurrentThread.CurrentCulture;

            dataTableSenores = new DataTable();

            dBHelperSenor = new DBHelperSenor();

            dBHelperPayment = new DBHelperPayment();

            listAllSenores = dBHelperSenor.read();

            wantedSenores = listAllSenores;

            listPaymentsThisMonth = dBHelperPayment.read(getMonth(DateTime.Now.Month), DateTime.Now.Year);

            loadDataInDataTable();

            menuItem_listPayments.BackColor = generateColor("#fddb1a");

            dataGridView_senores.BackgroundColor = generateColor("#88561a");

            button_add.BackColor = generateColor("#3fe72b");

            button_update.BackColor = generateColor("#2b8fe7");

            button_clean.BackColor = generateColor("#32f0ea");

            button_delete.BackColor = generateColor("#f04932");

            loadDataInComboBox();

            //getDataInTextBox();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBox_searchSenores.GotFocus += new EventHandler(this.TextGotFocus);
            textBox_searchSenores.LostFocus += new EventHandler(this.TextLostFocus);
        }

        public string myNumberFormat(float xyz)
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            NumberFormatInfo nfi;

            if (currentCulture.ToString() == "en-US")
            {
                // Gets a NumberFormatInfo associated with the en-US culture.
                nfi = new CultureInfo("en-US", false).NumberFormat;

                nfi.CurrencyDecimalSeparator = ".";
                nfi.CurrencyGroupSeparator = ",";
                nfi.CurrencySymbol = "";
                return Convert.ToDecimal(xyz).ToString("C2", nfi);
            }
            else
            {
                nfi = new CultureInfo("es", false).NumberFormat;

                nfi.CurrencyDecimalSeparator = ",";
                nfi.CurrencyGroupSeparator = " ";
                nfi.CurrencySymbol = "";
                return Convert.ToDecimal(xyz).ToString("C2", nfi);
            }

        }

        private void loadDataInDataTable()
        {

            loadData();

            //sets the width in the firts ans second column
            dataGridView_senores.Columns[0].Width = 40;
            dataGridView_senores.Columns[3].Width = 120;

            dataGridView_senores.EnableHeadersVisualStyles = false;


            //disable the sorting function when the user press any header
            foreach (DataGridViewColumn column in dataGridView_senores.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }

        //This method fill the data table with the DB data
        private void loadData()
        {
            this.totalMonthlyPayments = 0;

            foreach (Senor senor in wantedSenores)
            {
                int id = (senor.Id);
                string name = (senor.Name);
                string lastName = (senor.LastName);
                string monthlyPayment = "Pendiente";

                if (theCustomerHaveACurrentPayemnt(id))
                {
                    monthlyPayment = "Realizado";
                    totalMonthlyPayments += monthlyPaymentPrice;
                }

                dataGridView_senores.Rows.Add(id, name, lastName, monthlyPayment);
            }

            RowsColor(dataGridView_senores);

        }

        private void textBox_searchSenores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void textBox_searchSenores_TextChanged(object sender, EventArgs e)
        {
            if(textBox_searchSenores.Text == "Buscar..."){return;}
            if(wantedSenores.Count>=listAllSenores.Count && textBox_searchSenores.Text == "") { return; }

            wantedSenores = new List<Senor>();

            string wantedSenor = textBox_searchSenores.Text;

            foreach (Senor senor in listAllSenores)
            {
                string nameSenor = senor.Name;

                string lastNameSenor = senor.LastName;

                if (currentCulture.CompareInfo.IndexOf(nameSenor, wantedSenor, CompareOptions.IgnoreCase) >= 0 ||
                    currentCulture.CompareInfo.IndexOf(lastNameSenor, wantedSenor, CompareOptions.IgnoreCase) >= 0)
                {
                    wantedSenores.Add(senor);
                }

            }

            removeAllRowsFromDGV();
            dataGridView_senores.Refresh();

            loadData();

            RowsColor(dataGridView_senores);
        }

        private void removeAllRowsFromDGV()
        {

            do
            {
                foreach (DataGridViewRow row in dataGridView_senores.Rows)
                {
                    try
                    {
                        dataGridView_senores.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (dataGridView_senores.Rows.Count > 1);

            if (dataGridView_senores.Rows.Count == 1)
            {
                dataGridView_senores.Rows.Remove(dataGridView_senores.Rows[0]);
            }


        }

        public void RowsColor(DataGridView dataGrid)
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = generateColor("#ffffff");
                }
                else
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = generateColor("#d5cfcf");
                }

                if (dataGrid.Rows[i].Cells[3].Value.ToString() == "Realizado")
                {
                    dataGrid.Rows[i].Cells[3].Style.ForeColor = generateColor("#04e21f");
                }
                else
                {
                    dataGrid.Rows[i].Cells[3].Style.ForeColor = generateColor("#df0101");
                }

            }
        }

        private void listaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPanels[0].BringToFront();

            menuItem_listPayments.BackColor = generateColor("#fddb1a");
            menuItem_management.BackColor = generateColor("#cd853f");
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listPanels[1].BringToFront();

            menuItem_management.BackColor = generateColor("#fddb1a");
            menuItem_listPayments.BackColor = generateColor("#cd853f");
        }

        public System.Drawing.Color generateColor(string colorHexadecimal)
        {
            System.Windows.Media.Color color = (Color)ColorConverter.ConvertFromString(colorHexadecimal);

            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;

            string lastName = textBox_lastName.Text;

            if (dBHelperSenor.insert(name, lastName))
            {
                dataGridView_senores.Rows.Add(dBHelperSenor.maxId(), name, lastName, "Pendiente");

                cleanTextBox();

                RowsColor(dataGridView_senores);

                dataGridView_senores.CurrentCell = dataGridView_senores.Rows[dataGridView_senores.RowCount - 1].Cells[0];

                getDataInTextBox();

                listAllSenores = dBHelperSenor.read();
            }
            else
            {
                MessageBox.Show("Hubo un problema al agregar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void cleanTextBox()
        {
            textBox_name.Text = "";

            textBox_lastName.Text = "";
        }

        private void button_clean_Click(object sender, EventArgs e)
        {
            cleanTextBox();
        }

        private void dataGridView_senores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            getDataInTextBox();

            int rowIndex = dataGridView_senores.CurrentCell.RowIndex;

            DataGridViewRow row = dataGridView_senores.Rows[rowIndex];

            if (row.Cells[3].Value.ToString() == "Pendiente")
            {
                button_add_payment.Text = "Agregar Pago";
            }
            else
            {
                button_add_payment.Text = "Remover Pago";
            }
        }

        private void getDataInTextBox()
        {

            int rowIndex = dataGridView_senores.CurrentCell.RowIndex;

            DataGridViewRow row = dataGridView_senores.Rows[rowIndex];

            textBox_name.Text = row.Cells[1].Value.ToString();

            textBox_lastName.Text = row.Cells[2].Value.ToString();

        }

        private void button_update_Click(object sender, EventArgs e)
        {

            if (dataGridView_senores.CurrentCell == null) { return; }

            if (!(MessageBox.Show("¿Seguro que deseas actualizar este registro?", "Por favor, confirme:",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                return;
            }

            int rowIndex = dataGridView_senores.CurrentCell.RowIndex;

            DataGridViewRow row = dataGridView_senores.Rows[rowIndex];

            int id = int.Parse(row.Cells[0].Value.ToString());

            string name = textBox_name.Text;

            string lastName = textBox_lastName.Text;

            if (dBHelperSenor.update(id, name, lastName))
            {
                dataGridView_senores.Rows[rowIndex].Cells[1].Value = name;
                dataGridView_senores.Rows[rowIndex].Cells[2].Value = lastName;

                dataGridView_senores.Refresh();
            }
            else
            {
                MessageBox.Show("Hubo un problema al actualizar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {

            if (dataGridView_senores.CurrentCell == null) { return; }

            int rowIndex = dataGridView_senores.CurrentCell.RowIndex;

            DataGridViewRow row = dataGridView_senores.Rows[rowIndex];

            int id = int.Parse(row.Cells[0].Value.ToString());

            if (!(MessageBox.Show("Seguro que deseas eliminar este registro permanentemente?", "Por favor, confirme:",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                return;
            }

            if (dBHelperSenor.delete(id))
            {
                dataGridView_senores.Rows.RemoveAt(rowIndex);

                cleanTextBox();

                RowsColor(dataGridView_senores);
            }
            else
            {
                MessageBox.Show("Hubo un problema al borrar el registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void button_generateBill_Click(object sender, EventArgs e)
        {

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);

            int columns = 2;

            //PDFTable fondos externos
            PdfPTable pdfTable = new PdfPTable(columns);
            pdfTable.DefaultCell.Padding = 7;
            pdfTable.WidthPercentage = 100;
            pdfTable.DefaultCell.BorderWidth = 1;



            int rowIndex = dataGridView_senores.CurrentCell.RowIndex;

            DataGridViewRow row = dataGridView_senores.Rows[rowIndex];

            if (row.Cells[3].Value.ToString() == "Pendiente")
            {
                MessageBox.Show("El cliente seleccionado no tiene registrado el pago de la mensualidad. Agreguelo para poder generar la factura.", "Agregue un pago", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Payment payment = getPaymentCurrentMonthByIDSenor(int.Parse(row.Cells[0].Value.ToString()));

            DateTime dateTime = DateTime.Parse(payment.PayDate);

            int day = dateTime.Day;

            int month = dateTime.Month;

            int year = dateTime.Year;

            string name = row.Cells[1].Value.ToString();

            string lastName = row.Cells[2].Value.ToString();


            pdfTable.AddCell(new Phrase("Recibimos de: ", text));
            pdfTable.AddCell(new Phrase(name + " " + lastName, text));
            pdfTable.AddCell(new Phrase("La suma de: ", text));
            pdfTable.AddCell(new Phrase(monthlyPaymentPrice + "", text));
            pdfTable.AddCell(new Phrase("Cancela el mes de: ", text));
            pdfTable.AddCell(new Phrase(getMonth(comboBox_months.SelectedIndex + 1), text));
            pdfTable.AddCell(new Phrase("Fecha de pago: ", text));
            pdfTable.AddCell(new Phrase(day + " de " + getMonth(month) + " del " + year, text));


            //------------------------------------------------------------------//


            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = "Factura de " + name + " " + lastName + " - " + getMonth(comboBox_months.SelectedIndex + 1);
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                        PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();

                        //--------------------//

                        //Image logo = Image.GetInstance("..\\images\\logoCentroDiurno.jpg");
                        //Image logo = Image.GetInstance("C:\\images\\logoCentroDiurno.jpg");
                        Image logo = Image.GetInstance("..\\images\\logoCentroDiurno.jpg");
                        logo.ScaleAbsolute(100, 60);
                        logo.Alignment = Element.ALIGN_CENTER;

                        iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 16);
                        iTextSharp.text.Font regularFont = FontFactory.GetFont("Arial", 14);
                        Paragraph title;
                        Paragraph textParagrahp;
                        title = new Paragraph("Asociación Centro De Atención Al Adulto Mayor De Cachí\n", titleFont);
                        title.Alignment = Element.ALIGN_CENTER;

                        pdfdoc.Add(logo);

                        pdfdoc.Add(title);

                        pdfdoc.Add(new Paragraph("\n", titleFont));

                        pdfdoc.Add(pdfTable);

                        pdfdoc.Close();
                        stream.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("No se puede guardar el archivo, ya que está siendo usado en este momento por otra aplicación.", "Cierre el archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



            }

        }

        private string getMonth(int monthNumber)
        {
            switch (monthNumber)
            {
                case 1:
                    return "Enero";
                case 2:
                    return "Febrero";
                case 3:
                    return "Marzo";
                case 4:
                    return "Abril";
                case 5:
                    return "Mayo";
                case 6:
                    return "Junio";
                case 7:
                    return "Julio";
                case 8:
                    return "Agosto";
                case 9:
                    return "Septiembre";
                case 10:
                    return "Octubre";
                case 11:
                    return "Noviembre";
                case 12:
                    return "Diciembre";
            }

            return "";
        }

        public void loadDataInComboBox()
        {
            comboBox_months.Items.Add("Enero");
            comboBox_months.Items.Add("Febrero");
            comboBox_months.Items.Add("Marzo");
            comboBox_months.Items.Add("Abril");
            comboBox_months.Items.Add("Mayo");
            comboBox_months.Items.Add("Junio");
            comboBox_months.Items.Add("Julio");
            comboBox_months.Items.Add("Agosto");
            comboBox_months.Items.Add("Septiembre");
            comboBox_months.Items.Add("Octubre");
            comboBox_months.Items.Add("Noviembre");
            comboBox_months.Items.Add("Diciembre");

            DateTime dt = DateTime.Now;
            int currentMonth = dt.Month - 1;

            comboBox_months.SelectedIndex = currentMonth;

        }

        private Boolean theCustomerHaveACurrentPayemnt(int idCustomer)
        {
            foreach (Payment payment in listPaymentsThisMonth)
            {
                if (payment.IdSenor == idCustomer)
                {
                    return true;
                }
            }

            return false;

        }

        private void button_add_payment_Click(object sender, EventArgs e)
        {
            if(button_add_payment.Text=="Agregar Pago")
            {
                AddPayment();  
            }
            else
            {
                DeletePayment();
            }

            


        }

        private void DeletePayment()
        {
            if (dataGridView_senores.CurrentCell == null) { return; }

            int rowIndex = dataGridView_senores.CurrentCell.RowIndex;

            DataGridViewRow row = dataGridView_senores.Rows[rowIndex];

            int idSenor = int.Parse(row.Cells[0].Value.ToString());

            Payment payment = getPaymentCurrentMonthByIDSenor(idSenor);

            if (!(MessageBox.Show("¿Seguro que deseas remover el pago?", "Por favor, confirme:",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                return;
            }

            if (dBHelperPayment.delete(payment.Id))
            {
                dataGridView_senores.Rows[rowIndex].Cells[3].Value = "";
                dataGridView_senores.Rows[rowIndex].Cells[3].Value = "Pendiente";
                dataGridView_senores.Rows[rowIndex].Cells[3].Style.ForeColor = generateColor("#df0101");
                listPaymentsThisMonth = dBHelperPayment.read(getMonth(DateTime.Now.Month), DateTime.Now.Year);
                totalMonthlyPayments -= (monthlyPaymentPrice);
                button_add_payment.Text = "Agregar Pago";
            }
            else
            {
                MessageBox.Show("Hubo un problema al remover el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void AddPayment()
        {

            int rowIndex = dataGridView_senores.CurrentCell.RowIndex;

            DataGridViewRow row = dataGridView_senores.Rows[rowIndex];

            int idSenor = int.Parse(row.Cells[0].Value.ToString());

            int month = comboBox_months.SelectedIndex + 1;

            Senor senor = getSenorByID(idSenor);

            if (row.Cells[3].Value.ToString() == "Realizado")
            {
                MessageBox.Show("El cliente ya tiene el mes de " + getMonth(month) + " cancelado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!(MessageBox.Show("¿Agregar pago a " + senor.Name + " " + senor.LastName + " del mes de " + getMonth(comboBox_months.SelectedIndex + 1) + "?", "Por favor, confirme:",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                return;
            }

            if (dBHelperPayment.insert(DateTime.Now.ToString("yyyy-MM-dd"), getMonth(month), idSenor))
            {

                dataGridView_senores.Rows[rowIndex].Cells[3].Value = "";
                dataGridView_senores.Rows[rowIndex].Cells[3].Value = "Realizado";
                dataGridView_senores.Rows[rowIndex].Cells[3].Style.ForeColor = generateColor("#04e21f");
                listPaymentsThisMonth = dBHelperPayment.read(getMonth(DateTime.Now.Month), DateTime.Now.Year);
                totalMonthlyPayments += monthlyPaymentPrice;
                button_add_payment.Text = "Remover Pago";

            }
            else
            {
                MessageBox.Show("Hubo un problema al realizar el pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void comboBox_months_SelectedValueChanged(object sender, EventArgs e)
        {

            int month = comboBox_months.SelectedIndex + 1;

            listPaymentsThisMonth = dBHelperPayment.read(getMonth(month), DateTime.Now.Year);

            removeAllRowsFromDGV();

            loadDataInDataTable();

        }

        private void generateAllBills()
        {

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            int columns = 2;

            PdfPTable pdfTable = null;

            int monthX = comboBox_months.SelectedIndex + 1;

            var savefiledialoge = new SaveFileDialog();

            savefiledialoge.FileName = "Facturas del mes de " + getMonth(monthX);

            savefiledialoge.DefaultExt = ".pdf";

            listPaymentsThisMonth = dBHelperPayment.read(getMonth(monthX), DateTime.Now.Year);

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                    {

                        Document pdfdoc = new Document(PageSize.A4, 50f, 50f, 50f, 50f);
                        PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();

                        Image logo = Image.GetInstance("..\\images\\logoCentroDiurno.jpg");

                        int i = 0;

                        foreach (Payment payment in listPaymentsThisMonth)
                        {
                            i++;

                            //PDFTable fondos externos
                            pdfTable = new PdfPTable(columns);
                            pdfTable.DefaultCell.Padding = 7;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.DefaultCell.BorderWidth = 1;

                            DateTime dateTime = DateTime.Parse(payment.PayDate);

                            int day = dateTime.Day;

                            int month = dateTime.Month;

                            int year = dateTime.Year;

                            int idSenor = payment.IdSenor;

                            Senor senor = getSenorByID(idSenor);

                            string name = senor.Name;

                            string lastName = senor.LastName;


                            pdfTable.AddCell(new Phrase("Recibimos de: ", text));
                            pdfTable.AddCell(new Phrase(name + " " + lastName, text));
                            pdfTable.AddCell(new Phrase("La suma de: ", text));
                            pdfTable.AddCell(new Phrase(monthlyPaymentPrice + "", text));
                            pdfTable.AddCell(new Phrase("Cancela el mes de: ", text));
                            pdfTable.AddCell(new Phrase(getMonth(comboBox_months.SelectedIndex + 1), text));
                            pdfTable.AddCell(new Phrase("Fecha de pago: ", text));
                            pdfTable.AddCell(new Phrase(day + " de " + getMonth(month) + " del " + year, text));



                            logo.ScaleAbsolute(100, 60);
                            logo.Alignment = Element.ALIGN_CENTER;

                            iTextSharp.text.Font titleFont = FontFactory.GetFont("Arial", 16);
                            iTextSharp.text.Font regularFont = FontFactory.GetFont("Arial", 14);
                            Paragraph title;
                            Paragraph textParagrahp;
                            title = new Paragraph("Asociación Centro De Atención Al Adulto Mayor De Cachí\n", titleFont);
                            title.Alignment = Element.ALIGN_CENTER;

                            pdfdoc.Add(logo);

                            pdfdoc.Add(title);

                            pdfdoc.Add(new Paragraph("\n", titleFont));

                            pdfdoc.Add(pdfTable);

                            pdfdoc.Add(new Paragraph("\n", titleFont));

                            if (i % 3 == 0)
                            {
                                pdfdoc.NewPage();
                            }



                        }//foreach

                        pdfdoc.Close();
                        stream.Close();

                    }

                }
                catch (Exception ex)
                {
                    Console.Write(ex);
                    MessageBox.Show("No se puede guardar el archivo, ya que está siendo usado en este momento por otra aplicación.", "Cierre el archivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }


        }

        private Senor getSenorByID(int id)
        {
            foreach (Senor senor in listAllSenores)
            {
                if (senor.Id == id)
                {
                    return senor;
                }
            }

            return null;

        }

        private void button_monthlyPaymentsTotal_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Precio de la mensualidad: " + myNumberFormat(monthlyPaymentPrice) + " colones"
                + "\nCantidad de mensualidades canceladas del mes de " + getMonth(comboBox_months.SelectedIndex + 1) + ": " + totalMonthlyPayments / monthlyPaymentPrice
                + "\nTotal recaudado: " + myNumberFormat(totalMonthlyPayments) + " colones", "Información de las mensualidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private Payment getPaymentCurrentMonthByIDSenor(int id)
        {

            foreach(Payment payment in listPaymentsThisMonth)
            {
                if (payment.IdSenor == id)
                {
                    return payment;
                }
            }

            return new Payment();

        }

        public void TextGotFocus(object sender, EventArgs e)
        {

            if (textBox_searchSenores.Text == "Buscar...")
            {
                textBox_searchSenores.Text = "";
                textBox_searchSenores.ForeColor = generateColor("#000000");
            }

        }

        public void TextLostFocus(object sender, EventArgs e)
        {
            
            if (textBox_searchSenores.Text == "")
            {
                textBox_searchSenores.Text = "Buscar...";
                textBox_searchSenores.ForeColor = generateColor("#aeaeae");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generateAllBills();
        }

        private void radioButton_does_not_cancel_CheckedChanged(object sender, EventArgs e)
        {

            listAllSenores = dBHelperSenor.read();

            textBox_searchSenores.Text = "Buscar...";
            textBox_searchSenores.ForeColor = generateColor("#aeaeae");

            List<Senor> listAux = new List<Senor>();

            removeAllRowsFromDGV();

            foreach (Senor senor in listAllSenores)
            {

                int id = (senor.Id);

                if (!theCustomerHaveACurrentPayemnt(id))
                {  
                    string name = (senor.Name);
                    string lastName = (senor.LastName);
                    string monthlyPayment = "Pendiente";

                    listAux.Add(senor);

                    dataGridView_senores.Rows.Add(id, name, lastName, monthlyPayment);
                }
                
            }

            listAllSenores = listAux;

            RowsColor(dataGridView_senores);


        }

        private void radioButton_all_CheckedChanged(object sender, EventArgs e)
        {

            listAllSenores = dBHelperSenor.read();

            textBox_searchSenores.Text = "Buscar...";
            textBox_searchSenores.ForeColor = generateColor("#aeaeae");

            removeAllRowsFromDGV();
         

            foreach (Senor senor in listAllSenores)
            {
                int id = (senor.Id);
                string name = (senor.Name);
                string lastName = (senor.LastName);
                string monthlyPayment = "Pendiente";

                if (theCustomerHaveACurrentPayemnt(id))
                {
                    monthlyPayment = "Realizado";
                    totalMonthlyPayments += monthlyPaymentPrice;
                }

                dataGridView_senores.Rows.Add(id, name, lastName, monthlyPayment);
            }

            RowsColor(dataGridView_senores);
        }

        private void radioButton_cancel_CheckedChanged(object sender, EventArgs e)
        {
            listAllSenores = dBHelperSenor.read();

            textBox_searchSenores.Text = "Buscar...";
            textBox_searchSenores.ForeColor = generateColor("#aeaeae");

            removeAllRowsFromDGV();

            List<Senor> listAux = new List<Senor>();

            foreach (Senor senor in listAllSenores)
            {

                int id = (senor.Id);

                if (theCustomerHaveACurrentPayemnt(id))
                {
                    string name = (senor.Name);
                    string lastName = (senor.LastName);
                    string monthlyPayment = "Realizado";

                    listAux.Add(senor);

                    dataGridView_senores.Rows.Add(id, name, lastName, monthlyPayment);
                }

            }

            listAllSenores = listAux;

            RowsColor(dataGridView_senores);
        }
    }
}
