using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace maganement
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowJavaChart();
        }
        Check chk = new Check();
        private void ShowJavaChart()
        {
            lblAllStaff.Text = chk.stringCheck("select count(*) from m_login");
            lblTodayDue.Text = chk.stringCheck("select count(*) from SaleList where TotalDue!=0 and InputDate='"+DateTime.Now.ToString("dd MMMM yyyy")+"' ");
            lblTodaySales.Text = chk.stringCheck("select count(*) from SaleList where InputDate='" + DateTime.Now.ToString("dd MMMM yyyy") + "' ");
            lblTodayStock.Text = chk.stringCheck("select count(*) from StockList where InputDate='" + DateTime.Now.ToString("dd MMMM yyyy") + "' ");

            pnlShowJavaChart.Controls.Add(new LiteralControl(@"
 <script>
        $(document).ready(function () {
           
            // Bar Chart

            Morris.Bar({
                element: 'bar-charts',
                data: [
                    { y: 'Sat', a: 10, b: 110 },
                    { y: 'Sun', a: 20, b: 100 },
                    { y: 'Mon', a: 25, b: 100 },
                    { y: 'Tue', a: 2, b: 150 },
                    { y: 'Wed', a: 50, b: 40 },
                    { y: 'Thu', a: 75, b: 65 },
                    { y: 'Fri', a: 100, b: 90 }
                ],
                xkey: 'y',
                ykeys: ['a', 'b'],
                labels: ['Total Sale', 'Total Due'],
                lineColors: ['#ff9b44', '#fc6075'],
                lineWidth: '3px',
                barColors: ['#ff9b44', '#fc6075'],
                resize: true,
                redraw: true
            });


            Morris.Donut({
                element: 'pie-charts',
                colors: [
                    '#ff9b44',
                    '#fc6075',
                    '#ffc999',
                    '#fd9ba8'
                ],
                data: [
                    { label: 'Employees', value: 350 },
                    { label: 'Clients', value: 105 },
                    { label: 'Projects', value: 45 },
                    { label: 'Tasks', value: 10 }
                ],
                resize: true,
                redraw: true
            });

        });
    </script>
            "));
        }
    }
}