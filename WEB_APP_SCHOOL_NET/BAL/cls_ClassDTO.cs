using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Linq;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.BAL
{
    [NotMapped]
    public class cls_ClassDTO : MST_CLASS
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_ClassDTO()
        {
            unitOfWork = new UnitOfWork();
        }


        public bool Save(MST_CLASS data)
        {
            try
            {
                unitOfWork.ClassRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Update(MST_CLASS data)
        {
            try
            {

                var item = unitOfWork.ClassRepository.Find(f => f.ClassId == data.ClassId);
                if (item != null)
                {
                    item.ClassName = data.ClassName;
                    item.UpdatedBy = data.UpdatedBy;
                    item.UpdatedDate = DateTime.Now;
                    unitOfWork.ClassRepository.Update(item);
                }
                unitOfWork.Save();
                return true;

            }
            catch (Exception ex)
            { return false; }
        }

        public List<MST_CLASS> GetOrgClass()
        {
            if (cls_Common.UserProfile == null)
            {
                return null;
            }
            var classes = unitOfWork.ClassRepository.Filter(f => f.Org_Id == cls_Common.UserProfile.ORG_ID).OrderBy(o => o.ClassName);
            return classes.ToList();
        }

        public List<MST_SUBJECT> GetClassSubject(int classId)
        {
            var result = unitOfWork.SubjectRepository.Filter(f => f.ClassId == classId).OrderBy(o => o.SubjectName);
            return result.ToList();
        }




        public bool DeleteClass(int classid)
        {
            try
            {
                using (var sectionctx = new ModelContext())
                {
                    var section = (from c in sectionctx.MST_SECTION
                                   where c.ClassId == classid
                                   select c).FirstOrDefault();
                    if (section != null)
                    {
                        sectionctx.MST_SECTION.Remove(section);
                        int svsec = sectionctx.SaveChanges();
                        return true;
                    }

                }

                using (var subjectctx = new ModelContext())
                {
                    var subject = (from s in subjectctx.MST_SUBJECT
                                   where s.ClassId == classid
                                   select s).FirstOrDefault();
                    if (subject != null)
                    {
                        subjectctx.MST_SUBJECT.Remove(subject);
                        int svsub = subjectctx.SaveChanges();
                        return true;
                    }
                }

                using (var ctx = new ModelContext())
                {
                    var cls = (from c in ctx.MST_CLASS
                               where c.ClassId == classid
                               select c).FirstOrDefault();
                    if (cls != null)
                    {
                        ctx.MST_CLASS.Remove(cls);
                        int svcls = ctx.SaveChanges();

                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteSubject(int subjectid)
        {
            try
            {
                using (var subctx = new ModelContext())
                {
                    var subj = (from c in subctx.MST_SUBJECT
                                where c.SubjectId == subjectid
                                select c).FirstOrDefault();
                    subctx.MST_SUBJECT.Remove(subj);
                    int svsec = subctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteSection(int sectionid)
        {
            try
            {
                using (var sectionctx = new ModelContext())
                {
                    var section = (from c in sectionctx.MST_SECTION
                                   where c.SectionId == sectionid
                                   select c).FirstOrDefault();
                    sectionctx.MST_SECTION.Remove(section);
                    int svsec = sectionctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }

    public class cls_Promoted_Student : Repository<TRN_STUDENT_PROMOTED_SETTING>
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_Promoted_Student()
        {
            unitOfWork = new UnitOfWork();
            
        }

        public bool Create(TRN_STUDENT_PROMOTED_SETTING exam)
        {
            try
            {
                unitOfWork.TrnStudentPromotedRepository.Create(exam);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

    [NotMapped]
    public class cls_ExamDTO
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_ExamDTO()
        {
            unitOfWork = new UnitOfWork();
        }

        public MST_EXAM GetExamSubSubjectId(int SubjectId, byte ExamTypeId, byte FinId)
        {
            return unitOfWork.ExamRepository.Filter(x => x.Fin_ID == FinId && x.ExamTypeId == ExamTypeId && x.SubjectId == SubjectId && x.SubSubjectId == null).FirstOrDefault();
        }


        public string GetAcademicYear(int FinId)
        {
            return unitOfWork.FinYear.Filter(x => x.Fin_ID == FinId).Select(x => x.Finyear_Format).SingleOrDefault();
        }

        public MST_EXAM GetById(int id)
        {
            MST_EXAM data = unitOfWork.ExamRepository.Filter(x => x.ExamId == id).SingleOrDefault();
            return data;
        }

        public MST_EXAM_REPORT GetExamReportById(int id)
        {
            MST_EXAM_REPORT data = unitOfWork.ExamReportRepository.Filter(x => x.ID == id).SingleOrDefault();
            return data;
        }
        public bool Create(MST_EXAM exam)
        {
            try
            {
                unitOfWork.ExamRepository.Create(exam);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Create(MST_EXAM_REPORT exam)
        {
            try
            {
                unitOfWork.ExamReportRepository.Create(exam);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(MST_EXAM examData)
        {
            try
            {
                unitOfWork.ExamRepository.Update(examData);
                unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(MST_EXAM_REPORT examReportData)
        {
            try
            {
                unitOfWork.ExamReportRepository.Update(examReportData);
                unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(MST_EXAM Exam)
        {
            try
            {
                List<MST_EXAM_REPORT> ExamReports = unitOfWork.ExamReportRepository.Filter(x => x.ExamId == Exam.ExamId).ToList();
                foreach (var ExamReport in ExamReports)
                {
                    unitOfWork.ExamReportRepository.Delete(ExamReport);
                    unitOfWork.Save();
                }
                unitOfWork.ExamRepository.Delete(Exam);
                unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int Fin_Id, int ExamTypeId, int ClassId)
        {
            try
            {
                var Subjects = unitOfWork.SubjectRepository.Filter(x => x.ClassId == ClassId);
                List<MST_EXAM> entity = new List<MST_EXAM>();
                foreach (var Subject in Subjects)
                {
                    entity.AddRange(unitOfWork.ExamRepository.Filter(x => x.Fin_ID == Fin_Id && x.ExamTypeId == ExamTypeId && x.SubjectId == Subject.SubjectId));
                }
                foreach (var Exam in entity)
                {
                    List<MST_EXAM_REPORT> ExamReports = unitOfWork.ExamReportRepository.Filter(x => x.ExamId == Exam.ExamId).ToList();
                    foreach (var ExamReport in ExamReports)
                    {
                        unitOfWork.ExamReportRepository.Delete(ExamReport);
                        unitOfWork.Save();
                    }
                    unitOfWork.ExamRepository.Delete(Exam);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }






    public class cls_Fee_Structure
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_Fee_Structure()
        {
            unitOfWork = new UnitOfWork();
        }

        public bool Save(MST_FEE_STRUCTURE data)
        {
            try
            {
                unitOfWork.FeeStructureRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool Update(MST_FEE_STRUCTURE data)
        {
            try
            {
                unitOfWork.FeeStructureRepository.Update(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public List<MST_FEE_STRUCTURE> GetFEE_STRUCTURE(int finId, int classId)
        {
            // unitOfWork = new UnitOfWork();
            var item = unitOfWork.FeeStructureRepository.Filter(f => f.ClassId == classId && f.Fin_ID == finId).ToList();
            return item;
        }

        private MST_FEE_STRUCTURE GetFEE_STRUCTURE(int finId, int classId, int feeId)
        {
            // unitOfWork = new UnitOfWork();
            var item = unitOfWork.FeeStructureRepository.Find(f => f.FeeId == feeId && f.ClassId == classId && f.Fin_ID == finId);
            return item;
        }

        //
        public void CreateFeeStructure(int finId, int classId, int feeId)
        {
            cls_FeeDTO obj = new cls_FeeDTO();
            var item = obj.GetFeeDetail(feeId, finId, classId);
            var structure = GetFEE_STRUCTURE(finId, classId, feeId);
            MST_FEE_STRUCTURE structureNew = new MST_FEE_STRUCTURE();
            structureNew.FeeDuration = item.MST_FEE.FeeDuration;
            structureNew.Fin_ID = finId;
            structureNew.ClassId = classId;
            structureNew.FeeId = feeId;

            var paymentType = ((EnumConstants.FeeDuration)item.MST_FEE.FeeDuration).ToString();
            if (paymentType == EnumConstants.FeeDuration.Anually.ToString())
            {
                structureNew.TermCount = 1;
            }
            else if (paymentType == EnumConstants.FeeDuration.HalfYearly.ToString())
            {
                structureNew.TermCount = item.MST_FEE.MST_FEE_TERM.Count();
            }
            else if (paymentType == EnumConstants.FeeDuration.Monthly.ToString())
            {
                structureNew.TermCount = item.MST_FEE.MST_FEE_TERM.Count();
            }
            else if (paymentType == EnumConstants.FeeDuration.OneTime.ToString())
            {
                structureNew.TermCount = 1;
            }
            else if (paymentType == EnumConstants.FeeDuration.Quartly.ToString())
            {
                structureNew.TermCount = item.MST_FEE.MST_FEE_TERM.Count();
            }
            structureNew.Fee_New_Amt = item.FeeAmount_New;
            structureNew.Total_New_Amt = item.FeeAmount_New * structureNew.TermCount;

            structureNew.Fee_Old_Amt = item.FeeAmount_Old;
            structureNew.Total_Old_Amt = item.FeeAmount_Old * structureNew.TermCount;
            //fEE_STRUCTURE.ClassId=
            if (structure != null)
            {
                structure.Fee_New_Amt = structureNew.Fee_New_Amt;// item.FeeAmount_New;
                structure.Total_New_Amt = structureNew.Total_New_Amt;// item.FeeAmount_New * structure.TermCount;

                structure.Fee_Old_Amt = structureNew.Fee_Old_Amt;// item.FeeAmount_Old;
                structure.Total_Old_Amt = structureNew.Total_Old_Amt;// item.FeeAmount_New * structure.TermCount;

                Update(structure);
            }
            else
            {
                Save(structureNew);
            }
        }

    }


    [NotMapped]
    public class cls_FeeDTO
    {

        UnitOfWork unitOfWork;// = new ModelContext();
        cls_Fee_Structure structure;
        public cls_FeeDTO()
        {
            unitOfWork = new UnitOfWork();
            structure = new cls_Fee_Structure();
        }

        public List<dynamic> GetFeeReceipt(long StudentId,int finyearId)
        {
            var data = from t in unitOfWork.FeeReceiptRepository.Filter(c=>c.StudentId==StudentId && c.Fin_Id==finyearId)
                       join o in unitOfWork.FeeTerm.All() on t.FeeTermId equals o.TermId
                       join x in unitOfWork.FeeRepository.All() on o.FeeId equals x.FeeId
                       join y in unitOfWork.FeeStructureRepository.All() on x.FeeId equals y.FeeId
                       where t.StudentId == StudentId && t.TotalFee > 0 
                       group t by new { t.FeeTermId, t.ReceiptNumber, t.SubmitDate, t.SubmitType } into g
                       select new
                       {
                           ReceiptNumber = g.Key.ReceiptNumber,
                           SubmitDate = g.Key.SubmitDate,
                           SubmitType = g.Key.SubmitType,
                           TotalFee = g.Max(t=>t.TotalFee),
                           FeeTerm = g.Max(o => o.MST_FEE_TERM.FeeTerm),
                           FeeDuration = g.Max(x => x.MST_FEE_TERM.MST_FEE.FeeDuration),
                           FeeName = g.Max(x=>x.MST_FEE_TERM.MST_FEE.FeeName)
                       };
            return data.ToList<dynamic>();
        }

        public bool Save(MST_FEE data)
        {
            try
            {
                unitOfWork.FeeRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Save(List<MST_STUDENTFEE_RECEIPT> data)
        {
            try
            {
                foreach (var item in data)
                {
                    if (item.TotalFee <= 0)
                        continue;
                    unitOfWork.StudentReceiptRepository.Create(item);
                    unitOfWork.Save();
                }
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool Update(MST_STUDENTFEE_RECEIPT data)
        {
            try
            {
                unitOfWork.StudentReceiptRepository.Update(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool Delete(MST_FEE data)
        {
            try
            {
                unitOfWork.FeeRepository.Delete(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool Save(MST_FEE_DETAIL data)
        {
            try
            {
                unitOfWork.FeeDetailRepository.Create(data);
                unitOfWork.Save();
                // structure.CreateFeeStructure(data.Fin_ID.Value,data.ClassId.Value,data.FeeId.Value);
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Save(MST_STUDENT_FEE data)
        {
            try
            {
                unitOfWork.StudentFeeRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }

        }
        public MST_STUDENT_FEE GetStudentFee(int StudentFeeId)
        {
            var getDatafromdb = unitOfWork.StudentFeeRepository.Filter(f => f.StudentFeeId == StudentFeeId).SingleOrDefault();
            return getDatafromdb;
        }
        public bool Update(MST_STUDENT_FEE data)
        {
            try
            {
                unitOfWork.StudentFeeRepository.Update(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool Update(MST_FEE_DETAIL data)
        {
            try
            {
                unitOfWork.FeeDetailRepository.Update(data);
                unitOfWork.Save();

                // structure.CreateFeeStructure(data.Fin_ID.Value, data.ClassId.Value, data.FeeId.Value);
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public List<MST_FEE> GetFeeFiltered(string AcademicYear)
        {
            List<MST_FEE> Fees = unitOfWork.FeeRepository.Filter(f => f.Org_ID == cls_Common.UserProfile.ORG_ID).ToList();
            return Fees;
        }

        public List<MST_FEE> GetFee()
        {
            var Fees = unitOfWork.FeeRepository.Filter(f => f.Org_ID == cls_Common.UserProfile.ORG_ID).ToList();
            return Fees;
        }

        public MST_FEE GetFee(int feeId)
        {
            var Fees = unitOfWork.FeeRepository.Find(f => f.FeeId == feeId);
            return Fees;
        }

        public List<MST_FEE_DETAIL> GetFeeDetails(int classId,int finId)
        {
            var classes = unitOfWork.FeeDetailRepository.Filter(f => f.MST_CLASS.ClassId == classId && f.Fin_ID==finId).ToList();
            return classes;
        }

        public List<dynamic> GetFeeDetail(int classId, string AcademicYear)
        {
            //         var classes = unitOfWork.FeeDetailRepository.Filter(f => f.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID);
            //         return classes.ToList();

            var finId = Convert.ToInt32(AcademicYear);
            var classes = from fee in GetFeeFiltered(AcademicYear)
                          join feedtl in GetFeeDetails(classId, finId) on fee.FeeId equals feedtl.FeeId into newtable
                          from j in newtable.DefaultIfEmpty(new MST_FEE_DETAIL())
                          //where j.ClassId == classId //&& j.Fin_ID == finId
                          select new
                          {
                              FeeId = fee.FeeId,
                              FeeDetailId = j.FeeDetailId,
                              FeeName = fee.FeeName,
                              FeeDuration = fee.FeeDuration,
                              // AcYear=string.IsNullOrEmpty(j.MST_FINYEAR.Finyear_Format)?"-": j.MST_FINYEAR.Finyear_Format,
                              //TermCount=j.MST_FEE.MST_FEE_TERM.Count(),
                              //Tearm=
                              FeeAmount_New = j == null ? 0 : j.FeeAmount_New,  //j.FeeAmount_New,
                              FeeAmount_Old = j == null ? 0 : j.FeeAmount_Old,
                              Remark = j == null ? string.Empty : j.Remark

                          };
            return classes.ToList<dynamic>();
        }

        public MST_FEE_DETAIL GetDataForEdit(int Feedtlid, int finYearID)
        {
            var getDatafromdb = unitOfWork.FeeDetailRepository.Filter(f => f.FeeDetailId == Feedtlid && f.Fin_ID == finYearID).SingleOrDefault();
            return getDatafromdb;
        }

        public MST_FEE_DETAIL GetFeeDetail(int feeId, int finYearID, int ClassId)
        {
            var getDatafromdb = unitOfWork.FeeDetailRepository.Find(f => f.FeeId == feeId && f.Fin_ID == finYearID && f.ClassId == ClassId);
            return getDatafromdb;
        }
        //Get Fee When we are submit new or updated exists one--we are using this
        public MST_FEE_DETAIL GetFeeDetails(int FeeDetailId,int classId, int finYearID)
        {
            var getDatafromdb = unitOfWork.FeeDetailRepository.Find(f =>f.FeeDetailId == FeeDetailId && f.Fin_ID == finYearID && f.ClassId == classId);
            return getDatafromdb;
        }
        public MST_FEE_DETAIL GetFeeDetail(int FeeDetailId)
        {
            var getDatafromdb = unitOfWork.FeeDetailRepository.Find(f => f.FeeDetailId == FeeDetailId);
            return getDatafromdb;
        }


        //public MST_FEE_DETAIL GetFeeDetail(int feeId, int finYearID)
        //{
        //    var getDatafromdb = unitOfWork.FeeDetailRepository.Find(f => f.FeeId == feeId && f.Fin_ID == finYearID);
        //    return getDatafromdb;
        //}

        //public List<MST_FEE_DETAIL> GetFee()
        //{
        //    var classes = unitOfWork.FeeDetailRepository.Filter(f => f.Org_ID == cls_Common.UserProfile.ORG_ID);
        //    return classes.ToList();
        //}
    }
    [NotMapped]
    public class cls_SectionDTO : MST_SECTION
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_SectionDTO()
        {
            unitOfWork = new UnitOfWork();
        }


        public bool Save(MST_SECTION data)
        {
            try
            {
                unitOfWork.SectionRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }


        public bool Update(MST_SECTION data)
        {
            try
            {
                var item = unitOfWork.SectionRepository.Find(f => f.SectionId == data.SectionId);
                if (item != null)
                {
                    item.SectionName = data.SectionName;
                    item.UpdatedBy = data.UpdatedBy;
                    item.UpdatedDate = DateTime.Now;
                    unitOfWork.SectionRepository.Update(item);
                }
                unitOfWork.Save();
                return true;
              
            }
            catch (Exception ex)
            { return false; }
        }

        public List<MST_SECTION> GetSectionClass()
        {
            var classes = unitOfWork.SectionRepository.Filter(f => f.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID).OrderBy(o => o.MST_CLASS.ClassName);
            return classes.ToList();
        }

        public List<MST_SECTION> GetSection(int classId)
        {
            var classes = unitOfWork.SectionRepository.Filter(f => f.ClassId == classId).OrderBy(o => o.SectionName);
            return classes.ToList();
        }

    }

    [NotMapped]
    public class cls_SubjectDTO : MST_SUBJECT
    {

        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_SubjectDTO()
        {
            unitOfWork = new UnitOfWork();
        }


        public bool Save(MST_SUBJECT data)
        {
            try
            {
                unitOfWork.SubjectRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool Delete(int SubSubjectId)
        {
            try
            {
                var student = unitOfWork.SubSubjectRepository.Find(f => f.SubSubjectId == SubSubjectId);
                unitOfWork.SubSubjectRepository.Delete(student);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<MST_SUBJECT> GetSubject()
        {
            var classes = unitOfWork.SubjectRepository.Filter(f => f.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID).OrderBy(o => o.MST_CLASS.ClassName);
            return classes.ToList();
        }
        public List<MST_SUBJECT> GetSubject(int ClassId)
        {
            var classes = unitOfWork.SubjectRepository.Filter(f => f.ClassId == ClassId);
            return classes.ToList();
        }

        public List<MST_SUB_SUBJECT> GetSubSubject()
        {
            var SubSubjects = unitOfWork.SubSubjectRepository.Filter(f => f.MST_SUBJECT.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID);
            return SubSubjects.ToList();
        }

        public List<TRN_STUDENT_SUBJECT> GetByStudentId(int StudentId)
        {
            var StudentSubjects = unitOfWork.StudentSubjectRepository.Filter(f => f.StudentId == StudentId);
            return StudentSubjects.ToList();
        }

        public bool Create(MST_SUB_SUBJECT subSubject)
        {
            try
            {
                unitOfWork.SubSubjectRepository.Create(subSubject);
                unitOfWork.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
    [NotMapped]
    public class cls_StudentDTO : MST_STUDENT
    {
        UnitOfWork unitOfWork;
        public cls_StudentDTO()
        {
            unitOfWork = new UnitOfWork();
        }

        public bool SavePromoted(MST_STUDENT_PROMOTED student)
        {
            try
            {
                if (student.PromotedId <= 0 || student == null)
                {
                    unitOfWork.MSTStudentPromotedRepository.Create(student);
                }
                else if (student.PromotedId > 0)
                {
                    unitOfWork.MSTStudentPromotedRepository.Update(student);
                }
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Save(MST_STUDENT student)
        {
            try
            {
                if (student.StudentId <= 0 || student == null)
                {
                    unitOfWork.StudentRepository.Create(student);
                }
                else if (student.StudentId > 0)
                {
                    unitOfWork.StudentRepository.Update(student);
                }
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(MST_STUDENT student)
        {
            try
            {
                unitOfWork.StudentRepository.Update(student);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int studentId)
        {
            try
            {
                var student = unitOfWork.StudentRepository.Find(f => f.StudentId == studentId);

                unitOfWork.StudentRepository.Delete(student);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private MST_STUDENT FindStudent(int studentId)
        {
            return unitOfWork.StudentRepository.Find(f => f.StudentId == studentId);
        }

        public List<dynamic> GetAllStudent()
        {
            var Student = unitOfWork.StudentRepository.Filter(f => f.MST_SECTION.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID).OrderBy(o => o.StudentName)
                          .Select(x => new
                          {
                              StudentId = x.StudentId,
                              FormNumber = x.FormNumber,
                              StudentName = x.StudentName,
                              ClassName = x.MST_SECTION.MST_CLASS.ClassName,
                              FatherName = x.FatherName,
                              CasteType = x.CasteType,
                              Gender = x.Gender,
                              ContactNumber = x.ContactNumber,
                          });
            return Student.ToList<dynamic>();
        }
        
        public List<dynamic> GetAllStudentNameWithFormNumber(int sectionid)
        {
            var Student = unitOfWork.StudentRepository.Filter(f => f.SectionId == sectionid).Select(x => new { StudentId = x.StudentId, StudentName = x.FormNumber.ToString() + "-" + x.StudentName }).OrderBy(o => o.StudentName);
            return Student.ToList<dynamic>();
        }

        public List<dynamic> GetAllStudentName(int finId,int sectionid)
        {
            var Student = unitOfWork.StudentRepository.Filter(f => f.Fin_ID == finId && f.SectionId == sectionid).Select(x => new { StudentId = x.StudentId, StudentName = x.FormNumber.ToString() + "-" + x.StudentName }).OrderBy(o => o.StudentName);
            return Student.ToList<dynamic>();
        }

        public List<dynamic> GetAllStudentPromoted(int finId, int sectionid)
        {
            var auditStudents = unitOfWork.MSTStudentPromotedRepository.Filter(f => f.Fin_ID == finId && f.SectionId == sectionid).Select(s=>s.StudentId).ToList();

            var students = unitOfWork.StudentRepository.Filter(f => (f.Fin_ID == finId && f.SectionId == sectionid) || (auditStudents.Contains(f.StudentId))).Select(x => new { StudentId = x.StudentId, StudentName = x.FormNumber.ToString() + " - " + x.StudentName }).OrderBy(o => o.StudentName);
            
            return students.ToList<dynamic>();
        }

        public bool PromotedFromOneClassToAnother(List<long> fromClassStudentIds,int fin_Id, int classId, int sectionId)
        {
            try
            {
                var stdents = unitOfWork.StudentRepository.Filter(f => fromClassStudentIds.Contains(f.StudentId)).ToList();
                stdents.ForEach(a =>
                {
                    a.ClassId = classId;
                    a.SectionId = sectionId;
                    a.Fin_ID = fin_Id;
                });
                unitOfWork.Save();
               // AddPromotedAuditTrailData(fromClassStudentIds, fin_Id, classId, sectionId, (byte)EnumConstants.StudentPromotedStatus.StudentPromoted);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            // return true;
        }

        private void AddPromotedAuditTrailData(List<long> studentIds, int fin_Id, int classId, int sectionId, byte promotedStatus)
        {
            foreach (long data in studentIds)
            {
                var find = unitOfWork.MSTStudentPromotedRepository.Find(f => f.StudentId == data && f.Fin_ID == fin_Id && f.ClassId == classId && f.SectionId == sectionId);
                if (find == null)
                {
                    MST_STUDENT_PROMOTED item = new MST_STUDENT_PROMOTED();
                    item.StudentId = data;
                    item.Fin_ID = fin_Id;
                    item.ClassId = classId;
                    item.SectionId = sectionId;
                    item.Status = promotedStatus;
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = cls_Common.UserProfile.Id;
                    SavePromoted(item);
                }
            }
        }
        public bool PromotedAuditTrailStudentsDetail(List<long> studentIds, int fin_Id, int classId, int sectionId, byte promotedStatus)
        {
            try
            {
                AddPromotedAuditTrailData(studentIds, fin_Id, classId, sectionId, promotedStatus);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            // return true;
        }
        public bool PromotedStudentsDetail(List<long> studentIds, int fin_Id, int classId, int sectionId, byte promotedStatus)
        {
            try
            {
                AddPromotedAuditTrailData(studentIds,fin_Id,classId,sectionId,promotedStatus);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            // return true;
        }

        public bool MoveStudentFromOneClassToAnother(List<long> fromClassStudentIds,int classId,int sectionId)
        {
            try
            {
                var stdents = unitOfWork.StudentRepository.Filter(f => fromClassStudentIds.Contains(f.StudentId)).ToList();
                stdents.ForEach(a =>
                {
                    a.ClassId = classId;
                    a.SectionId = sectionId;
                });
                unitOfWork.Save();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
          // return true;
        }

        //Method for get all student on basis of section based.
        public List<MST_STUDENT> GetAllStudent(int fin_Id, int sectionid)
        {
            var Student = unitOfWork.StudentRepository.Filter(f => f.Fin_ID == fin_Id && f.SectionId == sectionid).OrderBy(o => o.StudentName);
            return Student.ToList();
        }
        //Method for get all student on basis of class and section based.
        public List<MST_STUDENT> GetAllStudent(int fin_Id,int classid, int sectionid)
        {
            var Student = unitOfWork.StudentRepository.Filter(f => f.Fin_ID == fin_Id && f.ClassId == classid && f.SectionId == sectionid).OrderBy(o => o.StudentName);
            return Student.ToList();
        }
        public List<MST_CASTE> GetCastebycastetype(string castetype)
        {
            byte castetpy = (byte)(EnumConstants.Caste)Enum.Parse(typeof(EnumConstants.Caste), castetype);
            var caste = unitOfWork.CasteRepository.Filter(f => f.CasteType == castetpy).OrderBy(o => o.CasteId).ToList();
            return caste.ToList();
        }

        public MST_STUDENT GetDataForEdit(int studentid)
        {
            var getClass = unitOfWork.StudentRepository.Filter(f => f.StudentId == studentid).SingleOrDefault();
            return getClass;
        }

        public long GetformData()
        {
            var data = unitOfWork.StudentRepository.Filter(f => f.MST_SECTION.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID).Max(m => m.FormNumber);
            long total = data.HasValue ? data.Value + 1 : 1;
            return total;
        }

        //public void Rpt_StudentDetail()
        //{

        //    try
        //    {
        //        SqlParameter[] SqlParameters = new SqlParameter[] {
        //                                             new SqlParameter("@FINYEAR_ID",  2),
        //                                              new SqlParameter("@SECTION_ID", 19){ },
        //                                                new SqlParameter("@GENDER",  2),
        //                                                  new SqlParameter("@CASTETYPE",  "")
        //    };
        //        var products = unitOfWork.DataTableRecordSet.ExecWithStoreProcedure("PROC_RPT_STUDENT_TEST ", SqlParameters);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
        public DataTable RPT_StudentData(string finYearId)
        {
            int _finId = Convert.ToInt32(finYearId);


            var Student = unitOfWork.StudentRepository.Filter(f => (finYearId == null || (f.Fin_ID == _finId)) && f.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
            var data = from s in Student
                       select new
                       {
                           STUDENTID = s.StudentId,
                           FORMNUMBER = s.FormNumber,
                           ROLLNUMBER = s.RollNumber,
                           SERIALNUMBER = s.SerialNumber,
                           STUDENTNAME = s.StudentName,
                           FATHERNAME = s.FatherName,
                           MOTHERNAME = s.MotherName,
                           DOB = s.DOB.HasValue ? s.DOB.ToString() : "",
                           IMAGEURL = s.ImageUrl,
                           EMAIL = s.Email,
                           LASTSCHOOLNAME = s.LastSchoolName,
                           OCCUPATION = s.Occupation,
                           RESIDINGSINCE = s.ResidingSince,
                           GENDER = s.Gender == "M" ? "MALE" : "FEMALE",
                           REFERREDBY = s.ReferredBy,
                           SESSION = s.Session,
                           REFERREDMOBILENUMBER = s.ReferredMobileNumber,
                           CORRESPONDENCEADDRESS = s.CorrespondenceAddress,
                           PERMANENTADDRESS = s.PermanentAddress,
                           VILLAGE_TOWN = s.Village_Town,
                           CONTACTNUMBER = s.ContactNumber,
                           ZIPCODE = s.ZipCode,
                           NATIONALITY = s.Nationality,
                           WHATSAPPNO = s.WhatsAppNo,
                           NAME = s.MST_CLASS.MST_ORGANIZATION.Name,
                           IMAGE = s.MST_CLASS.MST_ORGANIZATION.Image,
                           IMAGEPATH = s.MST_CLASS.MST_ORGANIZATION.ImagePath,
                           FINYEAR = s.MST_FINYEAR.Finyear,
                           FINYEAR_FORMAT = s.MST_FINYEAR.Finyear_Format,
                           CLASSNAME = s.MST_CLASS.ClassName,
                           CASTEID = s.CasteId,
                           CASTETYPE = s.CasteType.HasValue ? ((EnumConstants.Caste)s.CasteType).ToString() : "NA"
                       };
            return data.AsDataTable();
        }
        public DataTable RPT_StudentData(string finYearId, string classId)
        {
            int _finId = Convert.ToInt32(finYearId);
            int _classId = Convert.ToInt32(classId);

            var Student = unitOfWork.StudentRepository.Filter(f => (finYearId == null || (f.Fin_ID == _finId)) && (classId == null || (f.ClassId == _classId)) && f.MST_CLASS.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
            var data = from s in Student
                       select new
                       {
                           STUDENTID = s.StudentId,
                           FORMNUMBER = s.FormNumber,
                           ROLLNUMBER = s.RollNumber,
                           SERIALNUMBER = s.SerialNumber,
                           STUDENTNAME = s.StudentName,
                           FATHERNAME = s.FatherName,
                           MOTHERNAME = s.MotherName,
                           DOB = s.DOB.HasValue ? s.DOB.ToString() : "",
                           IMAGEURL = s.ImageUrl,
                           EMAIL = s.Email,
                           LASTSCHOOLNAME = s.LastSchoolName,
                           OCCUPATION = s.Occupation,
                           RESIDINGSINCE = s.ResidingSince,
                           GENDER = s.Gender == "M" ? "MALE" : "FEMALE",
                           REFERREDBY = s.ReferredBy,
                           SESSION = s.Session,
                           REFERREDMOBILENUMBER = s.ReferredMobileNumber,
                           CORRESPONDENCEADDRESS = s.CorrespondenceAddress,
                           PERMANENTADDRESS = s.PermanentAddress,
                           VILLAGE_TOWN = s.Village_Town,
                           CONTACTNUMBER = s.ContactNumber,
                           ZIPCODE = s.ZipCode,
                           NATIONALITY = s.Nationality,
                           WHATSAPPNO = s.WhatsAppNo,
                           NAME = s.MST_CLASS.MST_ORGANIZATION.Name,
                           IMAGE = s.MST_CLASS.MST_ORGANIZATION.Image,
                           IMAGEPATH = s.MST_CLASS.MST_ORGANIZATION.ImagePath,
                           FINYEAR = s.MST_FINYEAR.Finyear,
                           FINYEAR_FORMAT = s.MST_FINYEAR.Finyear_Format,
                           CLASSNAME = s.MST_CLASS.ClassName,
                           CASTEID = s.CasteId,
                           CASTETYPE = s.CasteType.HasValue ? ((EnumConstants.Caste)s.CasteType).ToString() : "NA"
                       };
            return data.AsDataTable();
        }


        public DataTable RPT_StudentData(string finYearId, string sectionId, string gender, string casteType)
        {
            int _finId = Convert.ToInt32(finYearId);
            int _sectionId = Convert.ToInt32(sectionId);
            //  int _gender = Convert.ToInt32(gender);
            int _casteType = Convert.ToInt32(casteType);
            var Student = unitOfWork.StudentRepository.Filter(f => f.Fin_ID == _finId && f.SectionId == _sectionId && (gender == null || (f.Gender == gender)) && (casteType == null || (f.CasteType == _casteType))).ToList();
            var data = from s in Student
                       select new
                       {
                           STUDENTID = s.StudentId,
                           FORMNUMBER = s.FormNumber,
                           ROLLNUMBER = s.RollNumber,
                           SERIALNUMBER = s.SerialNumber,
                           STUDENTNAME = s.StudentName,
                           FATHERNAME = s.FatherName,
                           MOTHERNAME = s.MotherName,
                           DOB = s.DOB.HasValue ? s.DOB.ToString() : "",
                           IMAGEURL = s.ImageUrl,
                           EMAIL = s.Email,
                           LASTSCHOOLNAME = s.LastSchoolName,
                           OCCUPATION = s.Occupation,
                           RESIDINGSINCE = s.ResidingSince,
                           GENDER = s.Gender == "M" ? "MALE" : "FEMALE",
                           REFERREDBY = s.ReferredBy,
                           SESSION = s.Session,
                           REFERREDMOBILENUMBER = s.ReferredMobileNumber,
                           CORRESPONDENCEADDRESS = s.CorrespondenceAddress,
                           PERMANENTADDRESS = s.PermanentAddress,
                           VILLAGE_TOWN = s.Village_Town,
                           CONTACTNUMBER = s.ContactNumber,
                           ZIPCODE = s.ZipCode,
                           NATIONALITY = s.Nationality,
                           WHATSAPPNO = s.WhatsAppNo,
                           NAME = s.MST_CLASS.MST_ORGANIZATION.Name,
                           IMAGE = s.MST_CLASS.MST_ORGANIZATION.Image,
                           IMAGEPATH = s.MST_CLASS.MST_ORGANIZATION.ImagePath,
                           FINYEAR = s.MST_FINYEAR.Finyear,
                           FINYEAR_FORMAT = s.MST_FINYEAR.Finyear_Format,
                           CLASSNAME = s.MST_CLASS.ClassName,
                           CASTEID = s.CasteId,
                           CASTETYPE = s.CasteType.HasValue ? ((EnumConstants.Caste)s.CasteType).ToString() : "",
                           ADDRESS = s.MST_CLASS.MST_ORGANIZATION.Address
                       };
            return data.AsDataTable();
        }

    }

    [NotMapped]
    public class cls_StudentAttendanceDTO
    {
        UnitOfWork unitOfWork;
        public cls_StudentAttendanceDTO()
        {
            unitOfWork = new UnitOfWork();
        }
        //For save student attendance

        public bool Save(MST_STUDENT_ATTENDANCE studentattendance)
        {
            try
            {
                unitOfWork.StudentAttendanceRepository.Create(studentattendance);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(MST_STUDENT_ATTENDANCE studentattendance)
        {
            try
            {
                unitOfWork.StudentAttendanceRepository.Update(studentattendance);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public MST_STUDENT_ATTENDANCE GetDataForEdit(int studentAttendId, DateTime attendanceDate)
        {
            var getDatafromdb = unitOfWork.StudentAttendanceRepository.Filter(f => f.StudentAttendId == studentAttendId && DbFunctions.TruncateTime(f.PresentDate) == DbFunctions.TruncateTime(attendanceDate)).SingleOrDefault();
            return getDatafromdb;
        }

        //public MST_STUDENT_ATTENDANCE GetDataForEdit(int studentAttendId)
        //{
        //    var getDatafromdb = unitOfWork.StudentAttendanceRepository.Filter(f => f.StudentAttendId == studentAttendId).SingleOrDefault();
        //    return getDatafromdb;
        //}

        // ModelContext mx = new ModelContext();
        public List<dynamic> GetStudentAtt(int sectionid, DateTime attendanceDate)
        {
            var studentAtt = (from student in unitOfWork.StudentRepository.Filter(f => f.SectionId == sectionid)
                              join studentDtl in unitOfWork.StudentAttendanceRepository.Filter(f => f.SectionId == sectionid && DbFunctions.TruncateTime(f.PresentDate) == DbFunctions.TruncateTime(attendanceDate)) on student.StudentId equals studentDtl.StudentId into newtable
                              from j in newtable.DefaultIfEmpty()
                              select new
                              {
                                  StudentId = student.StudentId,
                                  RollNumber = student.RollNumber,
                                  StudentName = student.StudentName,
                                  StudentAttendId = j == null ? 0 : j.StudentAttendId,
                                  Presentbool = j == null ? false : j.IsPresent,
                                  PresentDate = j.PresentDate
                              }).ToList<dynamic>();
            return studentAtt;
        }
    }

    [NotMapped]
    public class cls_StudentSubjectDTO : TRN_STUDENT_SUBJECT
    {
        UnitOfWork unitOfWork;
        public cls_StudentSubjectDTO()
        {
            unitOfWork = new UnitOfWork();
        }
        public TRN_STUDENT_SUBJECT GetSubjectBy_StudentId_SubjectId(long? StudentId, int? SubjectId)
        {
            return unitOfWork.StudentSubjectRepository.Filter(x => x.StudentId == StudentId && x.SubjectId == SubjectId).FirstOrDefault(); ;
        }

        public bool Update(TRN_STUDENT_SUBJECT item)
        {
            try
            {
                unitOfWork.StudentSubjectRepository.Update(item);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool Save(TRN_STUDENT_SUBJECT item)
        {
            try
            {
                unitOfWork.StudentSubjectRepository.Create(item);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }

        public bool Delete(TRN_STUDENT_SUBJECT item)
        {
            try
            {
                unitOfWork.StudentSubjectRepository.Delete(item);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
    }

    [NotMapped]
    public class cls_OrganizationDTO
    {
        UnitOfWork unitOfWork;// = new ModelContext();
        public cls_OrganizationDTO()
        {
            unitOfWork = new UnitOfWork();
        }


        public bool Save(MST_ORGANIZATION data)
        {
            try
            {
                unitOfWork.OrganzationRepository.Create(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(MST_ORGANIZATION data)
        {
            try
            {
                unitOfWork.OrganzationRepository.Update(data);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public MST_ORGANIZATION GetORGANIZATION(int organizationId)
        {
            var organization = unitOfWork.OrganzationRepository.Find(f => f.Org_Id == organizationId);

            return organization;
        }
    }
}