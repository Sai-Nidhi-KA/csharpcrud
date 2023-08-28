using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace userdetail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-UDFFUK18\\SQLEXPRESS;Initial Catalog=RegistrationWeb;Integrated Security=True");
        public int user_id;
        private void Form1_Load(object sender, EventArgs e)
        {
            GetUserDetailRecord();
        }
        private void GetUserDetailRecord()
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM registrationdata", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();

            UserDetailRecordGridView.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO registrationdata VALUES (@firstname,@lastname,@Dateofbirth,@Gender,@phone,@email,@address,@state,@city,@username,@password,@cpassword)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox7.Text);
                cmd.Parameters.AddWithValue("@Dateofbirth", textBox2.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox8.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox9.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@state", textBox10.Text);
                cmd.Parameters.AddWithValue("@city", textBox5.Text);
                cmd.Parameters.AddWithValue("@username", textBox11.Text);
                cmd.Parameters.AddWithValue("@password", textBox6.Text);
                cmd.Parameters.AddWithValue("@cpassword", textBox12.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New User is saved in the database", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetUserDetailRecord();
                ResetFormControl();
            }
        }

        private bool IsValid()
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Firstname is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ResetFormControl();
        }

        private void ResetFormControl()
        {
            user_id = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();

            textBox1.Focus();
        }

        private void UserDetailRecordGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            user_id = Convert.ToInt32(UserDetailRecordGridView.SelectedRows[0].Cells[0].Value);
            textBox1.Text = UserDetailRecordGridView.SelectedRows[0].Cells[1].Value.ToString();
            textBox7.Text = UserDetailRecordGridView.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = UserDetailRecordGridView.SelectedRows[0].Cells[3].Value.ToString();
            textBox8.Text = UserDetailRecordGridView.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = UserDetailRecordGridView.SelectedRows[0].Cells[5].Value.ToString();
            textBox9.Text = UserDetailRecordGridView.SelectedRows[0].Cells[6].Value.ToString();
            textBox4.Text = UserDetailRecordGridView.SelectedRows[0].Cells[7].Value.ToString();
            textBox10.Text = UserDetailRecordGridView.SelectedRows[0].Cells[8].Value.ToString();
            textBox5.Text = UserDetailRecordGridView.SelectedRows[0].Cells[9].Value.ToString();
            textBox11.Text = UserDetailRecordGridView.SelectedRows[0].Cells[11].Value.ToString();
            textBox6.Text = UserDetailRecordGridView.SelectedRows[0].Cells[10].Value.ToString();
            textBox12.Text = UserDetailRecordGridView.SelectedRows[0].Cells[12].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (user_id > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE registrationdata SET firstname = @firstname,lastname = @lastname,dateofbirth = @Dateofbirth,Gender = @Gender,phone = @phone,email = @email,Address = @address,State = @state,city = @city,username = @username,password = @password,cpassword = @cpassword WHERE user_id = @id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                cmd.Parameters.AddWithValue("@lastname", textBox7.Text);
                cmd.Parameters.AddWithValue("@Dateofbirth", textBox2.Text);
                cmd.Parameters.AddWithValue("@Gender", textBox8.Text);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.AddWithValue("@email", textBox9.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@state", textBox10.Text);
                cmd.Parameters.AddWithValue("@city", textBox5.Text);
                cmd.Parameters.AddWithValue("@username", textBox11.Text);
                cmd.Parameters.AddWithValue("@password", textBox6.Text);
                cmd.Parameters.AddWithValue("@cpassword", textBox12.Text);
                cmd.Parameters.AddWithValue("@id", this.user_id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Information is updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetUserDetailRecord();
                ResetFormControl();
            }
            else
            {
                MessageBox.Show("Please select User Information ", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(user_id > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM  registrationdata  WHERE user_id = @id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", this.user_id);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Information is  deleted", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetUserDetailRecord();
                ResetFormControl();
            }
            else
            {
                MessageBox.Show("Please select User to delete ", "Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}