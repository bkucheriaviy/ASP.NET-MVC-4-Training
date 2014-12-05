using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EmailOrderProcessor : IOrderProcessor
    {
        private readonly EmailSettings _settings;

        public EmailOrderProcessor(EmailSettings settings)
        {
            _settings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _settings.UseSsl;
                smtpClient.Host = _settings.ServerName;
                smtpClient.Port = _settings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_settings.Username, _settings.Password);

                if (_settings.WriteToFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _settings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                var sb = new StringBuilder();
                sb.AppendLine("A new order has been submitted");
                sb.AppendLine("---");
                sb.AppendLine("Items:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price*line.Quantity;
                    sb.AppendFormat("{0}x{1}(subtotal: {2:c})", line.Quantity, line.Product.Name, subtotal);
                }
                sb.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue());
                sb.AppendLine("---");
                sb.AppendLine("Ship to:");
                sb.AppendLine(shippingDetails.Name);
                sb.AppendLine(shippingDetails.Line1);
                sb.AppendLine(shippingDetails.Line2 ?? "");
                sb.AppendLine(shippingDetails.Line3 ?? "");
                sb.AppendLine(shippingDetails.City);
                sb.AppendLine(shippingDetails.State ?? "");
                sb.AppendLine(shippingDetails.Country);
                sb.AppendLine(shippingDetails.Zip);
                sb.AppendLine("---");
                sb.AppendFormat("Gift wrap: {0}", shippingDetails.GiftWrap ? "Yes" : "No");

                var mailMessage = new MailMessage(_settings.MailFromAddress, _settings.MailToAddress,
                    "New order submitted!", sb.ToString());

                if (_settings.WriteToFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);
            }
        }
    }
}
