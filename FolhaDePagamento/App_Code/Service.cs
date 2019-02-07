using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]

public class Service : System.Web.Services.WebService
{
    public Service () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public bool ValidaCpf(string cpf)
    {
        int v1, v2;
        int d1 = Convert.ToInt16(cpf.Substring(9,1)),
            d2 = Convert.ToInt16(cpf.Substring(10, 1));

        v1 = (10 * (Convert.ToInt16(cpf.Substring(0, 1)))) + (9 * (Convert.ToInt16(cpf.Substring(1, 1)))) + (8 * (Convert.ToInt16(cpf.Substring(2, 1)))) + (7 * (Convert.ToInt16(cpf.Substring(3, 1)))) + (6 * (Convert.ToInt16(cpf.Substring(4, 1)))) + (5 * (Convert.ToInt16(cpf.Substring(5, 1)))) + (4 * (Convert.ToInt16(cpf.Substring(6, 1)))) + (3 * (Convert.ToInt16(cpf.Substring(7, 1)))) + (2 * (Convert.ToInt16(cpf.Substring(8, 1))));
        v1 = 11 - v1 % 11;

        if (v1 >= 10)
            v1 = 0;

        v2 = (11 * (Convert.ToInt16(cpf.Substring(0, 1)))) + (10 * (Convert.ToInt16(cpf.Substring(1, 1)))) + (9 * (Convert.ToInt16(cpf.Substring(2, 1)))) + (8 * (Convert.ToInt16(cpf.Substring(3, 1)))) + (7 * (Convert.ToInt16(cpf.Substring(4, 1)))) + (6 * (Convert.ToInt16(cpf.Substring(5, 1)))) + (5 * (Convert.ToInt16(cpf.Substring(6, 1)))) + (4 * (Convert.ToInt16(cpf.Substring(7, 1)))) + (3 * (Convert.ToInt16(cpf.Substring(8, 1)))) + (2 * v1);
        v2 = 11 - v2 % 11;
        if (v2 >= 10)
            v2 = 0;

        if ((v1 == d1) && (v2 == d2))
            return true;

        return false;
    }
    [WebMethod]
    public double ValidaInss(double salario)
    {
        if ((salario <= 1174.86) && (salario > 0))
            return salario * 0.08;
        else
            if ((salario >= 1174.87) && (salario <= 1958.10))
                return salario * 0.09;
            else
                if ((salario >= 1958.11) && (salario <= 3916.20))
                    return salario * 0.11;
                else
                    if (salario > 3916.20)
                        return 3916.20 * 0.11;

        return salario;
    }

    [WebMethod]
    public double ValidaIr(double salario, int dependente)
    {
        salario -= (171.97 * dependente);

        if ((salario <= 1710.78) && (salario > 0))
            return 0;
        else
            if ((salario >= 1710.79) && (salario <= 2563.91))
                return salario * 0.075;
            else
                if ((salario >= 2563.92) && (salario <= 3418.59))
                    return salario * 0.15;
                else
                    if ((salario >= 3418.60) && (salario <= 4271.59))
                        return salario * 0.225;
                    else
                        if (salario > 4271.59)
                            return salario * 0.275;

        return salario;
    }
    
}