using System;
using System.Data;

namespace WEB_APP_SCHOOL_NET.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        private ModelContext context = new ModelContext();
        private Repository<MST_STATE> stateRepository;
        private Repository<MST_ORGANIZATION> orgRepository;
        private Repository<MST_CITY> cityRepository;
        private Repository<MST_CASTE> casteRepository;
        private Repository<MST_RELIGION> religionRepository;
        private Repository<MST_CONTENT> contentRepository;
        private Repository<MST_OCCUPATION> occupationRepository;
        private Repository<MST_CLASS> classRepository;
        private Repository<MST_SUBJECT> subjectRepository;
        private Repository<MST_SECTION> sectionRepository;
        private Repository<MST_STUDENT> studentRepository;
        private Repository<MST_FEE> feeRepository;
        private Repository<MST_STUDENT_ATTENDANCE> studentAttendanceRepository;
        private Repository<MST_FEE_DETAIL> feeDetailRepository;
        private Repository<MST_STUDENT_FEE> feeStudentRepository;
        private Repository<MST_FINYEAR> finyear;
        private Repository<MST_FEE_STRUCTURE> feeStructure;
        private Repository<MST_FEE_TERM> feeTerm;
        private Repository<TRN_STUDENT_SUBJECT> studentSubjectRepository;
        private Repository<MST_STUDENTFEE_RECEIPT> studentReceiptRepository;
        private Repository<MST_SUB_SUBJECT> subSubjectRepository;
        private Repository<MST_EXAM> examRepository;
        private Repository<MST_EXAM_REPORT> examReportRepository;
        private Repository<MST_DRIVER> driverRepository;
        private Repository<MST_VEHICLE> vehicleRepository;
        private Repository<MST_STUDENTFEE_RECEIPT> feeReceiptRepository;
        private Repository<MST_ROUTE_NAME> routeRepository;
        private Repository<MST_STOPNAME> stoppageRepository;
        private Repository<MST_ROUTE> routeManagementRepository;
        private Repository<MST_STUDENT_ROUTE> studentRouteSettingRepository;
        private Repository<TRN_STUDENT_PROMOTED_SETTING> trnStudentPromotedRepository;
        private Repository<MST_STUDENT_PROMOTED> mstStudentPromotedRepository;

        private Repository<DataTable> dt;

        public Repository<MST_STUDENT_PROMOTED> MSTStudentPromotedRepository
        {
            get
            {
                if (this.mstStudentPromotedRepository == null)
                {
                    this.mstStudentPromotedRepository = new Repository<MST_STUDENT_PROMOTED>(context);
                }
                return mstStudentPromotedRepository;
            }
        }
        public Repository<TRN_STUDENT_PROMOTED_SETTING> TrnStudentPromotedRepository
        {
            get
            {
                if (this.trnStudentPromotedRepository == null)
                {
                    this.trnStudentPromotedRepository = new Repository<TRN_STUDENT_PROMOTED_SETTING>(context);
                }
                return trnStudentPromotedRepository;
            }
        }

        public Repository<MST_STUDENTFEE_RECEIPT> FeeReceiptRepository
        {
            get
            {
                if (this.feeReceiptRepository == null)
                {
                    this.feeReceiptRepository = new Repository<MST_STUDENTFEE_RECEIPT>(context);
                }
                return feeReceiptRepository;
            }
        }
        public Repository<MST_ROUTE_NAME> RouteRepository
        {
            get
            {
                if (this.routeRepository == null)
                {
                    this.routeRepository = new Repository<MST_ROUTE_NAME>(context);
                }
                return routeRepository;
            }
        }
        public Repository<MST_STOPNAME> StoppageRepository
        {
            get
            {
                if (this.stoppageRepository == null)
                {
                    this.stoppageRepository = new Repository<MST_STOPNAME>(context);
                }
                return stoppageRepository;
            }
        }

        public Repository<MST_ROUTE> RouteManagementRepository
        {
            get
            {
                if (this.routeManagementRepository == null)
                {
                    this.routeManagementRepository = new Repository<MST_ROUTE>(context);
                }
                return routeManagementRepository;
            }
        }
        public Repository<MST_STUDENT_ROUTE> StudentRouteSettingRepository
        {
            get
            {
                if (this.studentRouteSettingRepository == null)
                {
                    this.studentRouteSettingRepository = new Repository<MST_STUDENT_ROUTE>(context);
                }
                return studentRouteSettingRepository;
            }
        }


        public Repository<MST_VEHICLE> VehicleRepository
        {
            get
            {
                if (this.vehicleRepository == null)
                {
                    this.vehicleRepository = new Repository<MST_VEHICLE>(context);
                }
                return vehicleRepository;
            }
        }
        public Repository<MST_DRIVER> DriverRepository
        {
            get
            {
                if (this.driverRepository == null)
                {
                    this.driverRepository = new Repository<MST_DRIVER>(context);
                }
                return driverRepository;
            }
        }

        public Repository<DataTable> DataTableRecordSet
        {
            get
            {
                if (this.dt == null)
                {
                    this.dt = new Repository<DataTable>(context);
                }
                return dt;
            }
        }

        public Repository<MST_EXAM> ExamRepository
        {
            get
            {
                if (this.examRepository == null)
                {
                    this.examRepository = new Repository<MST_EXAM>(context);
                }
                return examRepository;
            }
        }

        public Repository<MST_EXAM_REPORT> ExamReportRepository
        {
            get
            {
                if (this.examReportRepository == null)
                {
                    this.examReportRepository = new Repository<MST_EXAM_REPORT>(context);
                }
                return examReportRepository;
            }
        }


        public Repository<MST_SUB_SUBJECT> SubSubjectRepository
        {
            get
            {
                if (this.subSubjectRepository == null)
                {
                    this.subSubjectRepository = new Repository<MST_SUB_SUBJECT>(context);
                }
                return subSubjectRepository;
            }
        }

        public Repository<MST_STUDENTFEE_RECEIPT> StudentReceiptRepository
        {
            get
            {
                if (this.studentReceiptRepository == null)
                {
                    this.studentReceiptRepository = new Repository<MST_STUDENTFEE_RECEIPT>(context);
                }
                return studentReceiptRepository;
            }
        }

        public Repository<TRN_STUDENT_SUBJECT> StudentSubjectRepository
        {
            get
            {
                if (this.studentSubjectRepository == null)
                {
                    this.studentSubjectRepository = new Repository<TRN_STUDENT_SUBJECT>(context);
                }
                return studentSubjectRepository;
            }
        }

        public Repository<MST_FEE_TERM> FeeTerm
        {
            get
            {
                if (this.feeTerm == null)
                {
                    this.feeTerm = new Repository<MST_FEE_TERM>(context);
                }
                return feeTerm;
            }
        }

        public Repository<MST_FEE_STRUCTURE> FeeStructureRepository
        {
            get
            {
                if (this.feeStructure == null)
                {
                    this.feeStructure = new Repository<MST_FEE_STRUCTURE>(context);
                }
                return feeStructure;
            }
        }

        public Repository<MST_FINYEAR> FinYear
        {
            get
            {
                if (this.finyear == null)
                {
                    this.finyear = new Repository<MST_FINYEAR>(context);
                }
                return finyear;
            }
        }

        public Repository<MST_FEE_DETAIL> FeeDetailRepository
        {
            get
            {
                if (this.feeDetailRepository == null)
                {
                    this.feeDetailRepository = new Repository<MST_FEE_DETAIL>(context);
                }
                return feeDetailRepository;
            }
        }

        public Repository<MST_STUDENT_FEE> StudentFeeRepository
        {
            get
            {
                if (this.feeStudentRepository == null)
                {
                    this.feeStudentRepository = new Repository<MST_STUDENT_FEE>(context);
                }
                return feeStudentRepository;
            }
        }

        public Repository<MST_FEE> FeeRepository
        {
            get
            {
                if (this.feeRepository == null)
                {
                    this.feeRepository = new Repository<MST_FEE>(context);
                }
                return feeRepository;
            }
        }
        
        public Repository<MST_SECTION> SectionRepository
        {
            get
            {
                if (this.sectionRepository == null)
                {
                    this.sectionRepository = new Repository<MST_SECTION>(context);
                }
                return sectionRepository;
            }
        }


        public Repository<MST_SUBJECT> SubjectRepository
        {
            get
            {
                if (this.subjectRepository == null)
                {
                    this.subjectRepository = new Repository<MST_SUBJECT>(context);
                }
                return subjectRepository;
            }
        }

        public Repository<MST_CLASS> ClassRepository
        {
            get
            {
                if (this.classRepository == null)
                {
                    this.classRepository = new Repository<MST_CLASS>(context);
                }
                return classRepository;
            }
        }

        public Repository<MST_ORGANIZATION> OrganzationRepository
        {
            get
            {
                if (this.orgRepository == null)
                {
                    this.orgRepository = new Repository<MST_ORGANIZATION>(context);
                }
                return orgRepository;
            }
        }
        public Repository<MST_STATE> StateRepository
        {
            get
            {
                if (this.stateRepository == null)
                {
                    this.stateRepository = new Repository<MST_STATE>(context);
                }
                return stateRepository;
            }
        }
        public Repository<MST_CITY> CityRepository
        {
            get
            {
                if (this.cityRepository == null)
                {
                    this.cityRepository = new Repository<MST_CITY>(context);
                }
                return cityRepository;
            }
        }
        public Repository<MST_CASTE> CasteRepository
        {
            get
            {
                if (this.casteRepository == null)
                {
                    this.casteRepository = new Repository<MST_CASTE>(context);
                }
                return casteRepository;
            }
        }
        public Repository<MST_RELIGION> ReligionRepository
        {
            get
            {
                if (this.religionRepository == null)
                {
                    this.religionRepository = new Repository<MST_RELIGION>(context);
                }
                return religionRepository;
            }
        }

        public Repository<MST_CONTENT> ContentRepository
        {
            get
            {
                if (this.contentRepository == null)
                {
                    this.contentRepository = new Repository<MST_CONTENT>(context);
                }
                return contentRepository;
            }
        }
        public Repository<MST_OCCUPATION> OccupationRepository
        {
            get
            {
                if (this.occupationRepository == null)
                {
                    this.occupationRepository = new Repository<MST_OCCUPATION>(context);
                }
                return occupationRepository;
            }

        }
        public Repository<MST_STUDENT> StudentRepository
        {
            get
            {
                if (this.studentRepository == null)
                {
                    this.studentRepository = new Repository<MST_STUDENT>(context);
                }
                return studentRepository;
            }
        }

        public Repository<MST_STUDENT_ATTENDANCE> StudentAttendanceRepository
        {
            get
            {
                if (this.studentAttendanceRepository == null)
                {
                    this.studentAttendanceRepository = new Repository<MST_STUDENT_ATTENDANCE>(context);
                }
                return studentAttendanceRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        public void Update()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
