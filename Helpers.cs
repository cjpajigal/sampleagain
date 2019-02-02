using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace IncidentManagement
{
    public static class Helpers
    {

        
       
        public static bool isManager(IPrincipal user)
        {
            bool isManager = false;
            try
            {
                if (user.IsInRole("Network Unit Manager") || user.IsInRole("Network Manager") || user.IsInRole("Plant Manager") || user.IsInRole("Plant Operator") || user.IsInRole("OCC Engineer"))
                {
                    isManager = true;
                }
            }
            catch (Exception ex)
            {
            }
            return isManager;

        }

        public static bool isOccEngineer(IPrincipal user)
        {
            bool isOCC = false;
            try
            {
                if (user.IsInRole("OCC Engineer"))
                {
                    isOCC = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isOCC;

        }

        public static bool isOimSimCim(IPrincipal user)
        {
            bool blnOimSimCim = false;
            try
            {
                if (user.IsInRole("OIM") || user.IsInRole("SIM") || user.IsInRole("CIM"))
                {
                    blnOimSimCim = true;
                }
            }
            catch (Exception ex)
            {
            }
            return blnOimSimCim;
        }

        public static bool isOIM(IPrincipal user)
        {
            bool blnOIM = false;
            try
            {
                if (user.IsInRole("OIM") )
                {
                    blnOIM = true;
                }
            }
            catch (Exception ex)
            {
            }
            return blnOIM;
        }

        public static bool isSIM(IPrincipal user)
        {
            bool blnSIM = false;
            try
            {
                if (user.IsInRole("SIM"))
                {
                    blnSIM = true;
                }
            }
            catch (Exception ex)
            {
            }
            return blnSIM;
        }

        public static bool isCIM(IPrincipal user)
        {
            bool blnCIM = false;
            try
            {
                if ( user.IsInRole("CIM"))
                {
                    blnCIM = true;
                }
            }
            catch (Exception ex)
            {
            }
            return blnCIM;
        }

    }
}