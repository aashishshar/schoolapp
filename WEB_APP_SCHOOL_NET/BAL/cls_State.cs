using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WEB_APP_SCHOOL_NET.DAL;
using WEB_APP_SCHOOL_NET.Models;

namespace WEB_APP_SCHOOL_NET.BAL
{
    [NotMapped]
    public partial class cls_State : MST_STATE
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_State()
        {
            unitOfWork = new UnitOfWork();
        }


        public bool SaveState(MST_STATE mST_STATE)
        {
            try
            {
                unitOfWork.StateRepository.Create(mST_STATE);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool DeleteState(int stateid)
        {
            try
            {
                using (var ctx = new ModelContext())
                {
                    var state = (from s in ctx.MST_STATE
                                 where s.StateId == stateid
                                 select s).FirstOrDefault();

                    ctx.MST_STATE.Remove(state);

                    int num = ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
        public List<MST_STATE> GetStateMaster()
        {
            try
            {
                var stateItm = unitOfWork.StateRepository.All().OrderBy(o => o.StateName);
                return stateItm.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }

    [NotMapped]
    public partial class cls_City : MST_CITY
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public bool SaveCity(MST_CITY mST_City)
        {
            try
            {
                unitOfWork.CityRepository.Create(mST_City);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool DeleteCity(int cityid)
        {
            try
            {
                using (var ctx = new ModelContext())
                {
                    var city = (from s in ctx.MST_CITY
                                 where s.CityId == cityid
                                 select s).FirstOrDefault();

                    ctx.MST_CITY.Remove(city);

                    int num = ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<MST_CITY> GetCityMaster()
        {
            try
            {
                var cityItm = unitOfWork.CityRepository.All().OrderBy(o => o.CityName);
                return cityItm.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public List<MST_CITY> GetCity(int stateID)
        {
            try
            {
                var cityItm = unitOfWork.CityRepository.Filter(f=>f.StateId== stateID).OrderBy(o => o.CityName);
                return cityItm.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public List<MST_CITY> GetCityMaster(int stateID)
        {
            try
            {
                var cityItm = unitOfWork.CityRepository.Filter(f=>f.StateId== stateID).OrderBy(o => o.CityName);
                return cityItm.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }

    [NotMapped]
    public partial class cls_Caste : MST_CASTE
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public bool SaveCaste(MST_CASTE mST_CASTE)
        {
            try
            {
                unitOfWork.CasteRepository.Create(mST_CASTE);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool DeleteCaste(int casteid)
        {
            try
            {
                using (var ctx = new ModelContext())
                {
                    var caste = (from s in ctx.MST_CASTE
                                where s.CasteId == casteid
                                select s).FirstOrDefault();

                    ctx.MST_CASTE.Remove(caste);

                    int num = ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<MST_CASTE> GetCasteMaster()
        {
            try
            {
                var casteItm = unitOfWork.CasteRepository.All().OrderBy(o => o.CasteName);
                return casteItm.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        ///Get All Religion Name
        public List<MST_RELIGION> GetReligionMaster()
        {
            try
            {
                var religionItm = unitOfWork.ReligionRepository.All().OrderBy(o => o.ReligionName);
                return religionItm.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }

    [NotMapped]
    public partial class cls_Religion : MST_RELIGION
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public bool SaveReligion(MST_RELIGION mST_RELIGION)
        {
            try
            {
                unitOfWork.ReligionRepository.Create(mST_RELIGION);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool DeleteReligion(int religionid)
        {
            try
            {
                using (var ctx = new ModelContext())
                {
                    var religion = (from s in ctx.MST_RELIGION
                                 where s.ReligionId == religionid
                                 select s).FirstOrDefault();

                    ctx.MST_RELIGION.Remove(religion);

                    int num = ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<MST_RELIGION> GetReligionMaster()
        {
            try
            {
                var religionItm = unitOfWork.ReligionRepository.All().OrderBy(o => o.ReligionName);
                return religionItm.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }

    [NotMapped]
    public partial class cls_Occupation : MST_OCCUPATION
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public bool SaveOccupation(MST_OCCUPATION mST_OCCUPATION)
        {
            try
            {
                unitOfWork.OccupationRepository.Create(mST_OCCUPATION);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool DeleteOccupation(int occuid)
        {
            try
            {
                using (var ctx = new ModelContext())
                {
                    var occu = (from s in ctx.MST_OCCUPATION
                                    where s.Occupation_ID == occuid
                                    select s).FirstOrDefault();

                    ctx.MST_OCCUPATION.Remove(occu);

                    int num = ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<MST_OCCUPATION> GetOccupationMaster()
        {
            try
            {
                var occuItm = unitOfWork.OccupationRepository.All().OrderBy(o => o.OccupationName);
                return occuItm.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}