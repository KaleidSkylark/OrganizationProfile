using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        //Return Methods

        //Original
        public long StudentNumber(string studNum)
        {
            if (Regex.IsMatch(studNum, @"^[0-9]{5,11}$"))
            {
                _StudentNo = long.Parse(studNum);
            }
            return _StudentNo;
        }

        ////ArgumentNullException
        //public long StudentNumber(string studNum)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(studNum))
        //        {
        //            throw new ArgumentNullException("Student No.: is required!");
        //        }
        //        else
        //        {
        //            _StudentNo = long.Parse(studNum);
        //        }
        //    }
        //    catch (ArgumentNullException argument)
        //    {
        //        MessageBox.Show(argument.Message);
        //    }
        //    return _StudentNo;
        //}
        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;
        }

        //Original
        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            return _FullName;
        }

        ////Format Exception
        //public string FullName(string LastName, string FirstName, string MiddleInitial)
        //{
        //    try
        //    {
        //        if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
        //        {
        //            _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
        //        }
        //        else
        //        {
        //            throw new FormatException("Invalid Format!");
        //        }
        //    }
        //    catch (FormatException format)
        //    {
        //        MessageBox.Show(format.Message);
        //    }
        //    return _FullName;
        //}

        //Original
        public int Age(string age)
        {

            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;
        }

        ////OverFlowException
        //public int Age(string age)
        //{
        //    try
        //    {
        //        if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
        //        {
        //            _Age = Int32.Parse(age);
        //        }
        //        else
        //        {
        //            throw new OverflowException("Age: Incorrrect!");
        //        }
        //    }
        //    catch (OverflowException flow)
        //    {
        //        MessageBox.Show(flow.Message);
        //    }
        //    return _Age;
        //}

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
                 "BS Information Technology",
                 "BS Computer Science",
                 "BS Information Systems",
                 "BS in Accountancy",
                 "BS in Hospitality Management",
                 "BS in Tourism Management"
            };
            //Original
            for (int i = 0; i < 6; i++)
            {
                cmbProgram.Items.Add(ListOfProgram[i].ToString());
            }


            //IndexOutofRangeException
            //try
            //{
            //    if (ListOfProgram.Length == 8)
            //    {
            //        for (int i = 0; i < 6; i++)
            //        {
            //            cmbProgram.Items.Add(ListOfProgram[i].ToString());

            //        }
            //    }
            //    else
            //    {
            //        throw new IndexOutOfRangeException();
            //    }
            //}
            //catch (IndexOutOfRangeException outofrange)
            //{
            //    MessageBox.Show(outofrange.Message);
            //}

            string[] ListOfGender = new string[]{
                "Male","Female"
            };
            for (int a = 0; a < 2; a++)
            {
                cmbGender.Items.Add(ListOfGender[a].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //Validation not finished
            if (txtStudentNo.Text == "")
            {
                MessageBox.Show("Student No.: is required!", "Validatation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Regex.IsMatch(txtStudentNo.Text, "^[a-zA-Z]{5,11}"))
            {
                MessageBox.Show("Student No.: numeric only!", "Warning Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtFirstName.Text == "" || txtLastName.Text == "" && txtMI.Text == "")
            {
                MessageBox.Show("Full Name: is required!", "Validatation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Regex.IsMatch(txtLastName.Text, @"^[0-9]+$") || Regex.IsMatch(txtFirstName.Text, @"^[0-9]+$") || Regex.IsMatch(txtMI.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Full Name: alphabetical only!", "Validatation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtAge.Text == "")
            {
                MessageBox.Show("Age: is required!", "Validatation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Regex.IsMatch(txtAge.Text, @"^[a-zA-Z]{1,3}$"))
            {
                MessageBox.Show("Age: numeric only!", "Warning Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtContact.Text == "")
            {
                MessageBox.Show("Contact No.: is required!", "Validatation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (Regex.IsMatch(txtContact.Text, "^[a-zA-Z]{10,11}"))
            {
                MessageBox.Show("Contact No.: numeric only!", "Warning Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMI.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cmbProgram.Text;
                StudentInformationClass.SetGender = cmbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContact.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }

        }
    }
}