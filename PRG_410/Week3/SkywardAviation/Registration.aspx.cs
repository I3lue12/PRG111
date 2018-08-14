using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Page.IsPostBack

            && enrollmentForm.ActiveViewIndex == 0)

            hiddenPassword.Value = password.Text;
    }

    protected void Page_LoadComplete( object sender, EventArgs e)
    {
        if (Page.IsPostBack && enrollmentForm.ActiveViewIndex == 3)
        {
         //SqlConnection dbConnection = new SqlConnection("Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = "C:\Users\djulzz\Documents\GitHub\CCSD_WORK2\PRG_410\WEEK_3\STU dataFiles\Chapter.09\Chapter\SkywardAviation\App_Data\SkywardAviation.mdf"; Integrated Security = True
         SqlConnection dbConnection = new SqlConnection(ConnectionString.Value);

            try

            {

                dbConnection.Open();

                SqlCommand sqlCommand = new SqlCommand(

                    @"INSERT INTO FrequentFlyers (last, first, phone, email, password) VALUES("

                    //@"INSERT INTO FrequentFlyers (last, first,
                    //phone, email, password, cardType,
                    //expireMonth, expireYear, cardNumber,
                    //cardholder, address, city, state, zip,
                    //travelerType, homeAirport, class, seat,
                    //meal) VALUES("
                    + "'" + lastName.Text + "',"
                    + "'" + firstName.Text
                    + "',"
                    + "'" + telephone.Text + "',"
                    + "'" + email.Text
                    + "',"
                    + "'" + hiddenPassword.Value
                    //+ "',"
                    //+ "'" + creditcard.Text + "',"
                    //+ "'" + expireMonth.Text + "',"
                    //+ "'" + expireYear.Text + "',"
                    //+ "'" + cardnumber.Text + "',"
                    //+ "'" + cardholder.Text + "',"
                    //+ "'" + address.Text + "',"
                    //+ "'" + city.Text + "',"
                    //+ "'" + state.Text + "',"
                    //+ "'" + zip.Text + "',"
                    //+ "'" + travelerType.Text + "',"
                    //+ "'" + homeAirport.Text + "',"
                    //+ "'" + serviceClass.Text + "',"
                    //+ "'" + seatPreference.Text + "',"
                    //+ "'" + mealRequest.Text 
                    + "')",
                    dbConnection);

                sqlCommand.ExecuteNonQuery();
                sqlCommand = new SqlCommand( "SELECT IDENT_CURRENT('FrequentFlyers')", dbConnection);

                SqlDataReader lastID = sqlCommand.ExecuteReader();

                if (lastID.Read())
                    successString.Text +=
                @"<h3>Enrollment Successful</h3>
                <p>Your frequent flyer number is "
                + lastID.GetValue(0) + ".</p>";

            } catch (SqlException exception) {

                successString.Text += "<p>Error code "
                + exception.Number
                + ": " + exception.Message + "</p>";
            }
            dbConnection.Close();
        }
    }
}
