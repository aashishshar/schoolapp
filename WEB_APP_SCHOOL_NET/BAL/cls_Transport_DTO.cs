using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.BAL
{

    //[NotMapped]
    //public class cls_StoppageName
    //{
    //    UnitOfWork unitOfWork;// = new ModelContext();
    //    public MST_STOPNAME _item;
    //    public cls_StoppageName()
    //    {
    //        unitOfWork = new UnitOfWork();
    //    }

    //    public List<MST_STOPNAME> Get_StoppageNames()
    //    {
    //        return unitOfWork.StoppageRepository.Filter(f => f.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
    //    }

    //    public MST_STOPNAME Get_StoppageName(int stopId)
    //    {
    //        return unitOfWork.StoppageRepository.Find(f => f.StopId == stopId);
    //    }

    //    public bool Save(MST_STOPNAME data)
    //    {
    //        try
    //        {
    //            unitOfWork.StoppageRepository.Create(data);
    //            unitOfWork.Save();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        { return false; }
    //    }
    //    public bool Delete(MST_STOPNAME data)
    //    {
    //        try
    //        {
    //            unitOfWork.StoppageRepository.Delete(data);
    //            unitOfWork.Save();
    //            return true;
    //        }
    //        catch (Exception ex)
    //        { return false; }
    //    }

    //}

    [NotMapped]
    public class cls_StudentRouteSetting
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public MST_STUDENT_ROUTE _item;
        public cls_StudentRouteSetting()
        {
            unitOfWork = new UnitOfWork();
        }

        public List<MST_STUDENT_ROUTE> Get_RouteSettings()
        {
            return unitOfWork.StudentRouteSettingRepository.Filter(f => f.MST_ROUTE.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
        }

        public MST_STUDENT_ROUTE Get_RouteSetting(int assignRouteId)
        {
            return unitOfWork.StudentRouteSettingRepository.Find(f => f.AssignRouteId == assignRouteId);
        }

        public bool Save(MST_STUDENT_ROUTE data)
        {
            try
            {
                unitOfWork.StudentRouteSettingRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Delete(MST_STUDENT_ROUTE data)
        {
            try
            {
                unitOfWork.StudentRouteSettingRepository.Delete(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

    }

    [NotMapped]
    public class cls_RouteSetting
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public MST_ROUTE _item;
        public cls_RouteSetting()
        {
            unitOfWork = new UnitOfWork();
        }

        public List<MST_ROUTE> Get_RouteSettings()
        {
            return unitOfWork.RouteManagementRepository.Filter(f => f.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
        }

        public MST_ROUTE Get_RouteSetting(int studentRouteId)
        {
            return unitOfWork.RouteManagementRepository.Find(f => f.StudentRouteId == studentRouteId);
        }

        public bool Save(MST_ROUTE data)
        {
            try
            {
                unitOfWork.RouteManagementRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Delete(int studentRouteId)
        {
            try
            {
                var data = Get_RouteSetting(studentRouteId);
                unitOfWork.RouteManagementRepository.Delete(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

    }

    [NotMapped]
    public class cls_Route_Management
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public MST_ROUTE _item;
        public cls_Route_Management()
        {
            unitOfWork = new UnitOfWork();
        }

        public List<MST_ROUTE> Get_RouteManagements()
        {
            return unitOfWork.RouteManagementRepository.Filter(f => f.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
        }

        public MST_ROUTE Get_RouteManagement(int studentRouteId)
        {
            return unitOfWork.RouteManagementRepository.Find(f => f.StudentRouteId == studentRouteId);
        }

        public bool Save(MST_ROUTE data)
        {
            try
            {
                unitOfWork.RouteManagementRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Delete(MST_ROUTE data)
        {
            try
            {
                unitOfWork.RouteManagementRepository.Delete(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

    }

    [NotMapped]
    public class cls_Stoppage_Name
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        //public MST_STOPNAME _item;
        public cls_Stoppage_Name()
        {
            unitOfWork = new UnitOfWork();
        }

        public List<MST_STOPNAME> Get_Stoppages()
        {
            return unitOfWork.StoppageRepository.Filter(f => f.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
        }

        public MST_STOPNAME Get_Stoppage(int stopId)
        {
            return unitOfWork.StoppageRepository.Find(f => f.StopId == stopId);
        }

        public bool Save(MST_STOPNAME data)
        {
            try
            {
                unitOfWork.StoppageRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Delete(int stopId)
        {
            try
            {
                var data = Get_Stoppage(stopId);
                unitOfWork.StoppageRepository.Delete(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

    }

    [NotMapped]
    public class cls_Vehicle
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public MST_VEHICLE _item;
        public cls_Vehicle()
        {
            unitOfWork = new UnitOfWork();
        }

        public List<MST_VEHICLE> Get_Vehicles()
        {
            return unitOfWork.VehicleRepository.Filter(f => f.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
        }

        public MST_VEHICLE Get_Vehicle(int vehicleId)
        {
            return unitOfWork.VehicleRepository.Find(f => f.VehicleId == vehicleId);
        }

        public bool Save(MST_VEHICLE data)
        {
            try
            {
                unitOfWork.VehicleRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Delete(int vehicleId)
        {
            try
            {
                var data = Get_Vehicle(vehicleId);
                unitOfWork.VehicleRepository.Delete(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

    }

    [NotMapped]
    public class cls_Route_Name
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_Route_Name()
        {
            unitOfWork = new UnitOfWork();
        }

        

        public List<MST_ROUTE_NAME> Get_RouteS()
        {
            return unitOfWork.RouteRepository.Filter(f => f.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
        }

        public MST_ROUTE_NAME Get_Route(int routeId)
        {
            return unitOfWork.RouteRepository.Find(f => f.RouteId == routeId);
        }

        public bool Save(MST_ROUTE_NAME data)
        {
            try
            {
                unitOfWork.RouteRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Delete(int routeId)
        {
            try
            {
                var data = Get_Route(routeId);
                unitOfWork.RouteRepository.Delete(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

    }

    [NotMapped]
    public class cls_Driver_DTO
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public MST_DRIVER _getDriver;
        public cls_Driver_DTO()
        {
            unitOfWork = new UnitOfWork();           
        }

        public cls_Driver_DTO(int driverId)
        {
            unitOfWork = new UnitOfWork();
            _getDriver = Get_DRIVER(driverId);

        }

        public List<MST_DRIVER> Get_DRIVERS()
        {
            return unitOfWork.DriverRepository.Filter(f => f.OrgId == cls_Common.UserProfile.ORG_ID).ToList();
        }

        public MST_DRIVER Get_DRIVER(int driverId)
        {
          return  unitOfWork.DriverRepository.Find(f=>f.DriverId== driverId);
        }

        public bool Save(MST_DRIVER data)
        {
            try
            {
                unitOfWork.DriverRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Delete(MST_DRIVER data)
        {
            try
            {
                unitOfWork.DriverRepository.Delete(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

    }
}