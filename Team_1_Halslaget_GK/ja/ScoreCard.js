$(document).ready(function () {
        $("#ContentPlaceHolder1_TextBox1").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox2").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox3").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox4").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox5").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox6").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox7").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox8").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox9").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox10").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox11").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox12").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox13").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox14").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox15").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox16").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox17").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
        $("#ContentPlaceHolder1_TextBox18").on('change keyup paste', function () {
            document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
            document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
            document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
        });
});


var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(function () {
    $("#ContentPlaceHolder1_TextBox1").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox2").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox3").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox4").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox5").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox6").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox7").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox8").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox9").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = summarizeBox1to9();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox10").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox11").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox12").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox13").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox14").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox15").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox16").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox17").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
    $("#ContentPlaceHolder1_TextBox18").on('change keyup paste', function () {
        document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = summarizeBox10to18();
        document.getElementById('ContentPlaceHolder1_lblTotalt').innerHTML = CalculateTotal();
        document.getElementById('ContentPlaceHolder1_lblScore').innerHTML = CalculateScore();
    });
});


function summarizeBox1to9() {
    document.getElementById('ContentPlaceHolder1_lblIn').innerHTML = '';
    var box1 = document.getElementById('ContentPlaceHolder1_TextBox1').value;
    var box2 = document.getElementById('ContentPlaceHolder1_TextBox2').value;
    var box3 = document.getElementById('ContentPlaceHolder1_TextBox3').value;
    var box4 = document.getElementById('ContentPlaceHolder1_TextBox4').value;
    var box5 = document.getElementById('ContentPlaceHolder1_TextBox5').value;
    var box6 = document.getElementById('ContentPlaceHolder1_TextBox6').value;
    var box7 = document.getElementById('ContentPlaceHolder1_TextBox7').value;
    var box8 = document.getElementById('ContentPlaceHolder1_TextBox8').value;
    var box9 = document.getElementById('ContentPlaceHolder1_TextBox9').value;
    
    var result = +box1 + +box2 + +box3 + +box4 + +box5 + +box6 + +box7 + +box8 + +box9;

    return result;
}

function summarizeBox10to18() {
    document.getElementById('ContentPlaceHolder1_lblOut').innerHTML = '';
    var box10 = document.getElementById('ContentPlaceHolder1_TextBox10').value;
    var box11 = document.getElementById('ContentPlaceHolder1_TextBox11').value;
    var box12 = document.getElementById('ContentPlaceHolder1_TextBox12').value;
    var box13 = document.getElementById('ContentPlaceHolder1_TextBox13').value;
    var box14 = document.getElementById('ContentPlaceHolder1_TextBox14').value;
    var box15 = document.getElementById('ContentPlaceHolder1_TextBox15').value;
    var box16 = document.getElementById('ContentPlaceHolder1_TextBox16').value;
    var box17 = document.getElementById('ContentPlaceHolder1_TextBox17').value;
    var box18 = document.getElementById('ContentPlaceHolder1_TextBox18').value;

    var result = +box10 + +box11 + +box12 + +box13 + +box14 + +box15 + +box16 + +box17 + +box18;

    return result;
}

function CalculateTotal() {
    var inScore = document.getElementById('ContentPlaceHolder1_lblIn').textContent;
    var outScore = document.getElementById('ContentPlaceHolder1_lblOut').textContent;
    
    var total = +inScore + +outScore;

    return total;
}

function CalculateScore() {
    var totalString = document.getElementById('ContentPlaceHolder1_lblTotalt').textContent;
    var hcpString = document.getElementById('ContentPlaceHolder1_lblhcp').textContent;
    
    var totalFloat = parseFloat(totalString);
    var hcpStringDot = hcpString.replace(/,/g, '.');
    var hcpFloat = parseFloat(hcpStringDot);
    
    var score = totalFloat - hcpFloat;

    return score;
}