Imports System.Data.SqlClient
Imports Guna.UI2.WinForms

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Guna2Panel2.Visible = False
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Guna2Panel2.Visible = True
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        Dim form3 As New Form3(AccessibleDefaultActionDescription)
        form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Guna2Panel2.Visible = False
        Me.Show()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=ACER_NITRO_5;Initial Catalog=login;Integrated Security=True")
        Dim gender As String

        If RadioButton1.Checked Then
            gender = "Male"
        ElseIf RadioButton2.Checked Then
            gender = "Female"
        ElseIf RadioButton3.Checked Then
            gender = "Other"
        Else
            MessageBox.Show("Please select a gender.")
            Return
        End If

        con.Open()

        Dim cmd As SqlCommand = New SqlCommand("INSERT INTO student_detail
        (Fullname, Email, Phoneno, gender,rollno ,course, semester, permanent_adr, temporary_adr, Father_name, F_phoneno, Mother_name, M_phoneno, Guardian_name, G_phoneno)
        VALUES (@Fullname, @Email, @Phoneno, @gender, @rollno, @course, @semester, @permanent_adr, @temporary_adr, @Father_name, @F_phoneno, @Mother_name, @M_phoneno, @Guardian_name, @G_phoneno)", con)

        cmd.Parameters.AddWithValue("@Fullname", Guna2TextBox1.Text)
        cmd.Parameters.AddWithValue("@Email", Guna2TextBox2.Text)
        cmd.Parameters.AddWithValue("@Phoneno", Guna2TextBox3.Text)
        cmd.Parameters.AddWithValue("@gender", gender)
        cmd.Parameters.AddWithValue("@rollno", TextBox6.Text)
        cmd.Parameters.AddWithValue("@course", ComboBox12.SelectedItem.ToString())
        cmd.Parameters.AddWithValue("@semester", ComboBox1.SelectedItem.ToString())
        cmd.Parameters.AddWithValue("@permanent_adr", TextBox4.Text)
        cmd.Parameters.AddWithValue("@temporary_adr", TextBox7.Text)
        cmd.Parameters.AddWithValue("@Father_name", Guna2TextBox7.Text)
        cmd.Parameters.AddWithValue("@F_phoneno", Guna2TextBox9.Text)
        cmd.Parameters.AddWithValue("@Mother_name", Guna2TextBox8.Text)
        cmd.Parameters.AddWithValue("@M_phoneno", Guna2TextBox10.Text)
        cmd.Parameters.AddWithValue("@Guardian_name", Guna2TextBox12.Text)
        cmd.Parameters.AddWithValue("@G_phoneno", Guna2TextBox11.Text)

        cmd.ExecuteNonQuery()
        con.Close()

        MessageBox.Show("Student details inserted successfully.")
    End Sub
End Class
