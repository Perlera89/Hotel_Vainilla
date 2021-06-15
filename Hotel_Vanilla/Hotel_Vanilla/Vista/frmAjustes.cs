﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Hotel_Vanilla.CONTROLADOR;

namespace Hotel_Vanilla.Vista
{
    public partial class frmAjustes : Form
    {
        frmInicio inicio = new frmInicio();
        CEstados cEstados = new CEstados();
        CTipoHabitaciones cTipoH = new CTipoHabitaciones();
        CUsuarios cUsuarios = new CUsuarios();

        public frmAjustes()
        {
            InitializeComponent();
        }

        private void txtMensaje_Enter(object sender, EventArgs e)
        {
            if (txtMensaje.Text == "Mensaje")
                txtMensaje.Text = "";
        }

        private void txtMensaje_Leave(object sender, EventArgs e)
        {
            if (txtMensaje.Text == "")
                txtMensaje.Text = "Mensaje";
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
            MailMessage mensaje = new MailMessage();

            mensaje.To.Add("manuenitoo@gmail.com");
            mensaje.Subject = txtAsunto.Text;
            mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
            mensaje.Bcc.Add(frmInicio.Correo);
            mensaje.Body = txtMensaje.Text;
            mensaje.BodyEncoding = System.Text.Encoding.UTF8;
            mensaje.IsBodyHtml = true;
            mensaje.From = new MailAddress(frmInicio.Correo);

            //Envía el mensaje.
            SmtpClient cliente = new SmtpClient();
            cliente.Credentials = new NetworkCredential(frmInicio.Correo, frmInicio.Pass);
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";

                cliente.Send(mensaje);
                frmMensajeExito.Confirmar("El mensaje se ha enviado con exito");
            }

            catch (Exception)
            {
                frmMensajeAviso.Avisar("Error al enviar");
            }
        }

        private void frmAjustes_Load(object sender, EventArgs e)
        {
            CargarEstados();
            CargarTipoHabitaciones();
        }

        public void CargarEstados()
        {
            estadosBindingSource.DataSource = cEstados.MostrarEstados();
        }

        public void CargarTipoHabitaciones()
        {
            sp_MostrarTipoHabitacionesBindingSource.DataSource = cTipoH.MostrarTipoHabitaciones() ;
        }
    }
}
