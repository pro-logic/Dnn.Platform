﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetNuke.Entities.Controllers;
using DotNetNuke.Entities.Host;
using DotNetNuke.Entities.Modules;

namespace DNN.OAuth.AuthorizationServer.Core.Components
{
    /// <summary>
    /// This class is responsible for process and task that need to be performed during the upgrade of this library package
    /// </summary>
    public class BusinessController : IUpgradeable
    {
        public string UpgradeModule(string version)
        {
            string message = string.Empty;

            switch (version)
            {
                case "08.00.00":
                    GenerateAuthorizationServerPrivateKey();
                    
                    break;
            }

            return message;
        }

        /// <summary>
        /// this operation generates the authorization private key for oauth signing
        /// </summary>
        /// <remarks>this operation generates the authorization private key for oauth signing</remarks>
        private void GenerateAuthorizationServerPrivateKey()
        {
            try
            {
                HostController.Instance.Update("AuthorizationServerPrivateKey", "PFJTQUtleVZhbHVlPjxNb2R1bHVzPjkwNU9zRjVnYXNIOUVFY0VYV2RaSXNpNlozbWxKRjhlMFlPancrVmY0M0lYTnhmc3ZzOUxvdTR6dVpUOHV5dndpT25jaDUrSXBIOHZTZ2ZzaUZLbFZuQXRzcXhUcU5HVXFBWk5HWG9rZ3FiS0d6WTFoajZLVWxHUlErcThJMHdFbzBrWFh3cjQ3bWFIN01pRVYvaXBiSjZvVmtkbC9XVHJybXMyb2JFR09CRT08L01vZHVsdXM+PEV4cG9uZW50PkFRQUI8L0V4cG9uZW50PjxQPi9DSTYxZ1ZhZzlUMTRkMmdLb0hJSUc2NU5rQ0FzQlVzTlEzMGtRK2l2UEFIWTV5b2JpSXdxTDVxSk54cjhsVUhGMDJxQVR2TUxOYnNaT3J2a3V1bjF3PT08L1A+PFE+K3hrZ0pSQXJhRFRiem9VeElEbVZ4UVZtUVhia1NFS244bnpTYkZEN2ptSzRKd3h5NmlNR2ZTakljdFliNmhxQTc3dFlrTzFpSHVHTnZtS0FHMU9DVnc9PTwvUT48RFA+R1MwUjB1MFY3TFFIR1ZhWDk2YWQ1UjhwUDFHUmlBT1ZObmIrUkwzYThpTEZtaHk2ZE1UVk53Uk1kUUhOaFpVWDhDdkJIZjVxbE0raEt6S0tXWkZPWVE9PTwvRFA+PERRPjRQMnpldUpSTXE5aVlWdWhHREhoREVmNVJ5RmtEWWVFZTFmektGRXNCbnBZYmN6T3p4TVJSbWFicmFKQ0l2TWFvelNvZUR2c1ZxVmVYOEJjNzU5VlF3PT08L0RRPjxJbnZlcnNlUT5vVm5hNG1HQkx5SzN3OHdOQzhGVVBlVHlISzN5SkFSTXdDU0ZTLytTajI5eUdEbCtPeE5CRlNvUW9uWmwwdWFFeFdBN0VJTjJVZUxSZzhicWFELzUyQT09PC9JbnZlcnNlUT48RD5ZTkJQRGN4a2dtYWU0eGhxSlFhb1ptMmVTNVBiaW5tU1h3TGh3WGF5S3lBbTVuSi9ROU56RUwyZmtpODVJU3o2WlI3b0xrL045bGV6ODQ5V2thZUpBYUMzZm96c2Zrek9KVXBOQlNWS1RCRkR6K0dyRHV1a0tLL2JDbDBCVHZnT3E5R0k2UWUwUXpFUnV0SVIwUjY3cXptUUxmenRhVVc4UGVOSTcwTVhHZUU9PC9EPjwvUlNBS2V5VmFsdWU+");
                HostController.Instance.Update("ResourceServerDecryptionKey","PFJTQUtleVZhbHVlPjxNb2R1bHVzPjZlZnpYTHNvSmQ5OVVQMjdOQ1hWSnpZSFVtMmlLTUVOSlo2eVpVSFNvTE5uYnFMdENZWjZXaEl3SXY5WVBGeit0Z1AvQWN0dXh3N2VWVzdsU0RaU0IvQU8ySk1kOXJ1MkJ4SHRVaUZVd2pySnNHTlRUS1NhVDFDOTA0YXFaTExaRUxmYnVvVllabnFKWkRvdjlreTkwaHZtTTYwY3FXbkU4TGc2aGZSYlFPOD08L01vZHVsdXM+PEV4cG9uZW50PkFRQUI8L0V4cG9uZW50PjxQPjlrUjZaNGtabGVMeTlVMlo4WFl3WXd5VTA2d1g2UTR0QytlUitRZm5jOWJJK1loVFFRQXA1RXM1MGZwcWorWE8yQUhnb3RwN1NMRHdLSmZ5UmUzcElRPT08L1A+PFE+OHlacEFEUndhTG45MHFIY1liVG14N094b20wQVlrNVJnaDRyTTF1cGpNTEVHZTF5M01Xa2R0eUs0L3RsamVOeEJmOS82a0w4WTEyRU4zZDluaCtZRHc9PTwvUT48RFA+SW94VXg3V2FHMGJ0WXJCeVNrZVVYakRqcUJaYWZGMTZ3RkxLVGE5b0x2NFF6OERxUFJJeXprNG5YR2ZQRDBUa0ViV2h0L2NDbUo0Sjh3ZnQreFYzUVE9PTwvRFA+PERRPlhpOWd1TzJYSlZuMlVpTFVwUnhYMEw5d2JZUmZnN1RtcWNwWjNaa0NBajVuaTh1SWxMQVNWdUJ6QklDYkErMDRHS1N4dmVLWXRUekNQR0lTeks5Y1RRPT08L0RRPjxJbnZlcnNlUT5kcmVJNmhLaXFOVjZQWXEva2pybENpQk5XaGV1SVRUcGZTS0lEa0ZYd0xLaThrQ2hKcW1FWVltVjFqb2hOOVJEMzNEU2xGcnY0TXZ1cWFUWG5iMXBwdz09PC9JbnZlcnNlUT48RD5uTGZDUUpGTk53TGtyYzB6RHArQ2owRU42dFoxM2FSck1KZUJvNEpVbzBOUXU3b0I0MjNzc0VpYlkvZDlvUVFWek5Ja200azM4YnN1a0VNNjhBVWxNOUJqTGpNZjZmdFF3YlJWbUY0cllPZmZ4czhoUGszRXN3aWoycVlsNmxUMVpUaFM3MHd0MWlyQWQrWmFKNWN5V29HSnZVTWs4cWpQaWNSeEtkbEdub0U9PC9EPjwvUlNBS2V5VmFsdWU+");
                HostController.Instance.Update("AuthorizationServerVerificationKey","PFJTQUtleVZhbHVlPjxNb2R1bHVzPjkwNU9zRjVnYXNIOUVFY0VYV2RaSXNpNlozbWxKRjhlMFlPancrVmY0M0lYTnhmc3ZzOUxvdTR6dVpUOHV5dndpT25jaDUrSXBIOHZTZ2ZzaUZLbFZuQXRzcXhUcU5HVXFBWk5HWG9rZ3FiS0d6WTFoajZLVWxHUlErcThJMHdFbzBrWFh3cjQ3bWFIN01pRVYvaXBiSjZvVmtkbC9XVHJybXMyb2JFR09CRT08L01vZHVsdXM+PEV4cG9uZW50PkFRQUI8L0V4cG9uZW50PjwvUlNBS2V5VmFsdWU+");
            }
            catch (Exception ex)
            {
                DotNetNuke.Services.Exceptions.Exceptions.LogException(ex);
            }
        }
    }
}
