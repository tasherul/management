using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace management.Demo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "hwa", @"$(function() {
		var availableTags = [
			'ActionScript',
			'AppleScript',
			'Asp',
			'BASIC',
			'C',
			'C++',
			'Clojure',
			'COBOL',
			'ColdFusion',
			'Erlang',
			'Fortran',
			'Groovy',
			'Haskell',
			'Java',
			'JavaScript',
			'Lisp',
			'Perl',
			'PHP',
			'Python',
			'Ruby',
			'Scala',
			'Scheme'
		];
		$('#TextBox1').autocomplete({
			source: availableTags
		});
	});", true);
        }
    }
}