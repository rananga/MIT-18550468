using System.Web;
using System.Web.Optimization;

namespace StudentInformationSystem
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JavaScripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui-{version}.js",
                      "~/Scripts/jquery-ui-timepicker-addon.js",
                      "~/Scripts/jquery-ui-MonthPicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/site.js",
                      "~/Scripts/PopUpSelector.js",
                      "~/Scripts/fontawesome/all.js"));

            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                      "~/Scripts/Chart.js"));

            bundles.Add(new ScriptBundle("~/bundles/layout").IncludeDirectory(
                      "~/Scripts/Layout", "*.js", false));

            bundles.Add(new ScriptBundle("~/bundles/layoutless").Include(
                "~/Scripts/Layout/jquery.autosize.js",
                "~/Scripts/Layout/jquery.customSelect.js",
                //"~/Scripts/Layout/jquery.nicescroll.js",
                "~/Scripts/Layout/jquery.placeholder.js"//,
                //"~/Scripts/Layout/jquery.scrollTo.js",
                //"~/Scripts/Layout/jquery.slimscroll.js"
                ));

            bundles.Add(new StyleBundle("~/Scripts/bootstrapbundleminjs").Include(
                      "~/Scripts/bootstrap.bundle.min.js"));

            #endregion

            #region View Specific JS

            bundles.Add(new ScriptBundle("~/bundles/admin/user").Include(
                      "~/Scripts/Admin/User.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/userpermission").Include(
                      "~/Scripts/Admin/UserPermission.js"));

            bundles.Add(new ScriptBundle("~/bundles/academic/gradeclass").Include(
                      "~/Scripts/Academic/GradeClass.js"));

            bundles.Add(new ScriptBundle("~/bundles/academic/gradesubject").Include(
                      "~/Scripts/Academic/GradeSubject.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/employee").Include(
                      "~/Scripts/Admin/Employee.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/course").Include(
                      "~/Scripts/Program/Course.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/employeepromotion").Include(
                      "~/Scripts/Admin/EmployeePromotion.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/employeetransfer").Include(
                      "~/Scripts/Admin/EmployeeTransfer.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/allergies").Include(
                      "~/Scripts/Admin/Allergies.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/DailyPayment").Include(
                      "~/Scripts/Admin/DailyPayment.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/dailypaymentattendance").Include(
                      "~/Scripts/Admin/DailyPaymentAttendance.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/batch").Include(
                      "~/Scripts/Program/Batch.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/batchlecture").Include(
                      "~/Scripts/Program/BatchLecture.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/actualexpense").Include(
                      "~/Scripts/Program/ActualExpense.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/budget").Include(
                      "~/Scripts/Program/Budget.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/visitinglecturer").Include(
                     "~/Scripts/Program/VisitingLecturer.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/enrollment").Include(
                      "~/Scripts/Student/Enrollment.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/courseregistration").Include(
                      "~/Scripts/Student/CourseRegistration.js"));

            bundles.Add(new ScriptBundle("~/bundles/sponsor/sponsorpayment").Include(
                      "~/Scripts/Sponsor/SponsorPayment.js"));

            bundles.Add(new ScriptBundle("~/bundles/cashier/paymentreceipt").Include(
                      "~/Scripts/Cashier/PaymentReceipt.js"));

            bundles.Add(new ScriptBundle("~/bundles/finance/batchposting").Include(
                      "~/Scripts/Finance/BatchPosting.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/opdclaim").Include(
                      "~/Scripts/HR/OpdClaim.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/CommunicationReport").Include(
                      "~/Scripts/HR/CommunicationReport.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/Diagnosis").Include(
                       "~/Scripts/HR/Diagnosis.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/leavebalance").Include(
                       "~/Scripts/HR/LeaveBalance.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/report").Include(
                      "~/Scripts/Program/Report.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/dropout").Include(
                      "~/Scripts/Student/Dropout.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/transfer").Include(
                      "~/Scripts/Student/Transfer.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/otherinvoice").Include(
                      "~/Scripts/Student/OtherInvoice.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/refundedLibraryDeposit").Include(
                      "~/Scripts/Student/RefundedLibraryDeposit.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/batchsubject").Include(
                      "~/Scripts/Program/BatchSubject.js"));

            bundles.Add(new ScriptBundle("~/bundles/organization/generalexpense").Include(
                     "~/Scripts/Oraganization/GeneralExpense.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/employeepromotion").Include(
                 "~/Scripts/Admin/EmployeePromotion.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/communicationbill").Include(
                 "~/Scripts/HR/CommunicationBill.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/designation").Include(
                      "~/Scripts/Admin/Designation.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/lecturerextrahrs").Include(
                      "~/Scripts/Program/LecturerExtraHours.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/batchcancellation").Include(
                      "~/Scripts/Program/BatchCancellation.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/employeedutyleavecompletion").Include(
                       "~/Scripts/Admin/EmployeeDutyLeaveCompletion.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/examschedule").Include(
                       "~/Scripts/Program/ExamSchedule.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/industrialtraningregistration").Include(
                       "~/Scripts/Program/IndustrialTraningRegistration.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/examcandidate").Include(
                       "~/Scripts/Program/ExamCandidate.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/StudentAttendance").Include(
                       "~/Scripts/Program/StudentAttendance.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/signingsheet").Include(
                       "~/Scripts/Examination/ExamSigningSheet.js"));

            bundles.Add(new ScriptBundle("~/bundles/finance/transferconfirmation").Include(
                      "~/Scripts/Finance/TransferConfirmation.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/addMarks").Include(
                       "~/Scripts/Examination/AddMarks.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/examManagement").Include(
                       "~/Scripts/Examination/ExamManagement.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/examMarksSetup").Include(
                        "~/Scripts/Examination/ExamMarksSetup.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/otherExamMarks").Include(
                        "~/Scripts/Examination/OtherExamMarks.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/FuelConsumtion").Include(
                       "~/Scripts/Admin/FuelConsumtion.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/Report").Include(
                      "~/Scripts/Admin/Report.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/employeeLieuLeave").Include(
                 "~/Scripts/HR/EmployeeLieuLeave.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/employeeLeave").Include(
                 "~/Scripts/HR/EmployeeLeave.js"));

            bundles.Add(new ScriptBundle("~/bundles/notification").Include(
                       "~/Scripts/Notification.js"));

            bundles.Add(new ScriptBundle("~/bundles/organization/employeeinvoice").Include(
                    "~/Scripts/Oraganization/EmployeeInvoice.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/employeedutyleave").Include(
                 "~/Scripts/HR/EmployeeDutyLeave.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/employeeshortleave").Include(
                "~/Scripts/HR/EmployeeShortLeave.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/repeattransfer").Include(
                       "~/Scripts/Examination/RepeatTransfer.js"));

            bundles.Add(new ScriptBundle("~/bundles/library/issueCard").Include(
                        "~/Scripts/Library/IssueCard.js"));

            bundles.Add(new ScriptBundle("~/bundles/library/categorykeywords").Include(
                        "~/Scripts/Library/CategoryKeywords.js"));

            bundles.Add(new ScriptBundle("~/bundles/library/books").Include(
                        "~/Scripts/Library/Books.js"));

            bundles.Add(new ScriptBundle("~/bundles/library/bookedition").Include(
                        "~/Scripts/Library/BookEdition.js"));

            bundles.Add(new ScriptBundle("~/bundles/library/bookauthors").Include(
                        "~/Scripts/Library/BookAuthors.js"));

            bundles.Add(new ScriptBundle("~/bundles/callcentre/inquirycalls").Include(
                       "~/Scripts/callcentre/inquirycalls.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/contractemployeeleave").Include(
                "~/Scripts/HR/ContractEmployeeLeave.js"));

            bundles.Add(new ScriptBundle("~/bundles/oraganization/kpiEmpMarks").Include(
                "~/Scripts/Oraganization/KPIEmpMarks.js"));

            bundles.Add(new ScriptBundle("~/bundles/oraganization/kpiEmpMarksFinalize").Include(
                "~/Scripts/Oraganization/KPIEmpMarksFinalize.js"));

            bundles.Add(new ScriptBundle("~/bundles/oraganization/kpiEmpAttendance").Include(
                "~/Scripts/Oraganization/KPIEmpAttendance.js"));

            bundles.Add(new ScriptBundle("~/bundles/oraganization/confirmKpiMarks").Include(
                "~/Scripts/Oraganization/ConfirmKPIMarks.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/exambatchschedule").Include(
                       "~/Scripts/Examination/ExamBatchSchedule.js"));

            bundles.Add(new ScriptBundle("~/bundles/oraganization/kpiEmpProjMarks").Include(
                "~/Scripts/Oraganization/KPIEmpProjMarks.js"));

            bundles.Add(new ScriptBundle("~/bundles/oraganization/kpiEmpAttMarks").Include(
             "~/Scripts/Oraganization/KPIEmpAttMarks.js"));

            bundles.Add(new ScriptBundle("~/bundles/oraganization/kpidatesetup").Include(
            "~/Scripts/Oraganization/KPIDateSetUp.js"));

            bundles.Add(new ScriptBundle("~/bundles/organization/maxmarksetup").Include(
            "~/Scripts/Oraganization/KPIMakMarkSetup.js"));

            bundles.Add(new ScriptBundle("~/bundles/Program/EventAllocation").Include(
              "~/Scripts/Program/eventallocation.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/calcGPA").Include(
                    "~/Scripts/Program/CalcGPA.js"));

            bundles.Add(new ScriptBundle("~/bundles/Examination/ExamBoarderline").Include(
              "~/Scripts/Examination/examboarderline.js"));

            bundles.Add(new ScriptBundle("~/bundles/hr/medicalclaim").Include(
                "~/Scripts/HR/MedicalClaim.js"));
            bundles.Add(new ScriptBundle("~/bundles/examination/specialpermissionstudents").Include(
             "~/Scripts/Examination/SpecialPermissionStudents.js"));
            #endregion

            bundles.Add(new ScriptBundle("~/bundles/oraganization/kpisatisfactionmarks").Include(
          "~/Scripts/Oraganization/KPISatisfactionMarks.js"));

            bundles.Add(new ScriptBundle("~/bundles/oraganization/kpisupervisorreview").Include(
            "~/Scripts/Oraganization/KPISupervisorReview.js"));

            bundles.Add(new ScriptBundle("~/bundles/program/modulechecklist").Include(
                      "~/Scripts/Program/ModuleChecklist.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/medicalstudent").Include(
        "~/Scripts/Examination/MedicalStudent.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/employeeprobation").Include(
                 "~/Scripts/Admin/EmployeeProbation.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/staffmember").Include(
                 "~/Scripts/Admin/StaffMember.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/admin/vehicle").Include(
                "~/Scripts/Admin/vehicle.js"));
            bundles.Add(new ScriptBundle("~/bundles/student/courseinterview").Include(
                      "~/Scripts/Student/CourseInterview.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/actingemp").Include(
               "~/Scripts/Admin/ActingEmp.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/classregistration").Include(
              "~/Scripts/Student/ClassRegistration.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/studentpromotion").Include(
              "~/Scripts/Student/StudentPromotion.js"));

            bundles.Add(new ScriptBundle("~/bundles/cashier/donationreceipt").Include(
              "~/Scripts/Cashier/DonationReceipt.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/prefectguild").Include(
              "~/Scripts/Student/PrefectGuild.js"));


            bundles.Add(new ScriptBundle("~/bundles/student/studdropout").Include(
             "~/Scripts/Student/StudDropout.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/studenttransfer").Include(
           "~/Scripts/Student/StudentTransfer.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/studextracurricularsum").Include(
          "~/Scripts/Student/StudExtraCurricularSum.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/examination/examRepMediCandidate").Include(
              "~/Scripts/Examination/ExamRepMediCandidate.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/examcandidatelist").Include(
              "~/Scripts/Examination/ExamCandidateList.js"));

            bundles.Add(new ScriptBundle("~/bundles/student/reports").Include(
         "~/Scripts/Student/Reports.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/examattendance").Include(
              "~/Scripts/Examination/ExamAttendance.js"));

            bundles.Add(new ScriptBundle("~/bundles/examination/examresults").Include(
              "~/Scripts/Examination/ExamResults.js"));

            bundles.Add(new ScriptBundle("~/bundles/admin/staffmeetingattendance").Include(
            "~/Scripts/admin/StaffMeetingAttendance.js"));
            bundles.Add(new ScriptBundle("~/bundles/student/studentattendance").Include(
             "~/Scripts/Student/StudentAttendance.js"));
            bundles.Add(new ScriptBundle("~/bundles/examination/reports").Include(
              "~/Scripts/Examination/Reports.js"));
            bundles.Add(new ScriptBundle("~/bundles/student/onleavestudent").Include(
         "~/Scripts/Student/OnLeaveStudent.js"));
            
                  bundles.Add(new ScriptBundle("~/bundles/student/envelope").Include(
         "~/Scripts/Student/Envelope.js"));
            bundles.Add(new ScriptBundle("~/bundles/examination/examschedule").Include(
        "~/Scripts/Examination/ExamSchedule.js"));
            bundles.Add(new ScriptBundle("~/bundles/student/clubmembership").Include(
         "~/Scripts/Student/ClubMembership.js"));
            bundles.Add(new ScriptBundle("~/bundles/student/leavingcertificate").Include(
              "~/Scripts/Student/LeavingCertificate.js"));

            #region Styles

            bundles.Add(new StyleBundle("~/Content/jqueryuitimepicker").Include(
                      "~/Content/jquery-ui-timepicker-addon.css",
                      "~/Content/jquery-ui-MonthPicker.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                      "~/Content/Site.css",
                      "~/Content/PopUpSelector.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                      "~/Content/fontawesome-all.css"));

            bundles.Add(new StyleBundle("~/Content/Layout/LayoutBundle").IncludeDirectory(
                      "~/Content/Layout", "*.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrapicons").Include(
                      "~/Content/bootstrap-icons.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrapmin").Include(
                      "~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap.beta/bootstrapminbeta").Include(
                      "~/Content/bootstrap.beta/bootstrap.min.css"));

            #endregion
        }
    }
}
