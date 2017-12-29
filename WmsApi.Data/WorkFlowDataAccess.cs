using System.Collections.Generic;
using System.Linq;
using WmsApi.Data.Entities;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;
using System;

namespace WmsApi.Data
{
    public class WorkFlowDataAccess : IWorkFlowDataAccess
    {
        WMSContext db = new WMSContext();

        public ICollection<Common.Models.WorkFlow> GetWorkFlows()
        {
            return db.Workflow.Select(workFlow => new Common.Models.WorkFlow
            {
                Id = workFlow.Id,
                Version = workFlow.Version,
                Name = workFlow.Name,
                CreatedDate = workFlow.CreatedDate,
                CreatedBy = db.Employee.Select(s => new User { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Designation = s.Designation, Email = s.Email }).FirstOrDefault(u => u.Id == workFlow.CreatedBy),
                IsActive = workFlow.IsActive,
                Activities = workFlow.WorkflowActivity.Select(s => new Common.Models.WorkflowActivity { Id = s.Id, Type = new ActivityType { Id = s.Type }, Workflow = s.Workflow, WorkflowVersion = s.WorkflowVersion, Name = s.Name, ActivityOrderNumber = s.ActivityOrderNumber }).ToList()
            }).ToList();
        }

        public ICollection<Common.Models.WorkFlow> GetWorkFlowsByStatus(bool isActive)
        {
            return db.Workflow.Where(w => w.IsActive == isActive).Select(workFlow => new Common.Models.WorkFlow
            {
                Id = workFlow.Id,
                Version = workFlow.Version,
                Name = workFlow.Name,
                CreatedDate = workFlow.CreatedDate,
                CreatedBy = db.Employee.Select(s =>
                    new User
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Designation = s.Designation,
                        Email = s.Email
                    }).FirstOrDefault(u => u.Id == workFlow.CreatedBy),
                IsActive = workFlow.IsActive,
                Activities = workFlow.WorkflowActivity.Select(a =>
                    new Common.Models.WorkflowActivity
                    {
                        Id = a.Id,
                        Type = new ActivityType { Id = a.Type },//db.WorkflowActivityType.Select(st=>new ActivityType { Id = st.Id, Name = st.Name }).FirstOrDefault(at=>at.Id==a.Type),
                        Workflow = a.Workflow,
                        WorkflowVersion = a.WorkflowVersion,
                        Name = a.Name,
                        ActivityOrderNumber = a.ActivityOrderNumber,
                        Fields = a.WorkflowActivityField.Select(f => 
                            new Common.Models.WorkflowActivityField
                            {
                                Id = f.Id,
                                Activity = f.Activity,
                                Type = db.WorkflowActivityFieldType.Select(ft=> new ActivityFieldType { Id = ft.Id, ActivityType=ft.ActivityType, DataType=ft.DataType, Name=ft.Name }).FirstOrDefault(at => at.Id == f.Type),
                                Value = f.Value
                            }).ToList()
                    }).ToList()
            }).ToList();
        }

        public Common.Models.WorkFlow GetWorkFlow(int id)
        {
            return db.Workflow.Select(workFlow => new Common.Models.WorkFlow
            {
                Id = workFlow.Id,
                Version = workFlow.Version,
                Name = workFlow.Name,
                CreatedDate = workFlow.CreatedDate,
                CreatedBy = db.Employee.Select(s => new User { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Designation = s.Designation, Email = s.Email }).FirstOrDefault(u => u.Id == workFlow.CreatedBy),
                IsActive = workFlow.IsActive,
                Activities = workFlow.WorkflowActivity.Select(s => new Common.Models.WorkflowActivity { Id = s.Id, Type = new ActivityType { Id = s.Type }, Workflow = s.Workflow, WorkflowVersion = s.WorkflowVersion, Name = s.Name, ActivityOrderNumber = s.ActivityOrderNumber }).ToList()
            }).FirstOrDefault(w=>w.Id == id);
        }

        public int AddWorkFlow(Common.Models.WorkFlow workFlow)
        {
            Entities.Workflow WF = new Entities.Workflow
            {
                Id = workFlow.Id,
                Version = workFlow.Version,
                Name = workFlow.Name,
                CreatedDate = DateTime.Now,
                CreatedBy = workFlow.CreatedBy.Id,
                IsActive = workFlow.IsActive,
                WorkflowActivity = workFlow.Activities.Select(s =>
                    new Entities.WorkflowActivity
                    {
                        Id = s.Id,
                        Type = s.Type.Id,
                        Workflow = s.Workflow,
                        WorkflowVersion = s.WorkflowVersion,
                        Name = s.Name,
                        ActivityOrderNumber = s.ActivityOrderNumber,
                        WorkflowActivityField = s.Fields.Select(f =>
                        new Entities.WorkflowActivityField
                        {
                            Id = f.Id,
                            Activity = f.Activity,
                            Type = f.Type.Id,
                            Value = f.Value
                        }).ToList()
                    }).ToList()
            };
            db.Workflow.Add(WF);
            db.SaveChanges();
            return WF.Id;
        }

        public int StartWorkFlowExecution(Common.Models.WorkflowExecution execution)
        {
            Entities.WorkflowExecution WFE = new Entities.WorkflowExecution
            {
                Id = execution.Id,
                Workflow = execution.Workflow,
                WorkflowVersion = execution.WorkflowVersion,
                UserStory = execution.UserStory,
                StartDate = DateTime.Now,
                Status = execution.Status,
                Progress = execution.Progress,
                InitiatedBy = execution.InitiatedBy.Id,
                //EndDate = DateTime.Now,
                WorkflowActivityExecution = execution.ActivityExecutions.Select(s=>
                    new WorkflowActivityExecution
                    {
                        Id = s.Id,
                        WorkflowExecution = s.WorkflowExecution,
                        Activity = s.Activity.Id,
                        Status = s.Status,
                        StartDate = s.Status == "Started" ? DateTime.Now : default(DateTime),
                        OutCome = s.OutCome,
                        Comments = s.Comments,
                        //CompletedDate = DateTime.Now
                    }).ToList()
            };
            db.WorkflowExecution.Add(WFE);
            db.SaveChanges();
            return WFE.Id;
        }

        public int CompleteWorkFlowExecution(Common.Models.WorkflowExecution execution)
        {
            Entities.WorkflowExecution WFE = db.WorkflowExecution.FirstOrDefault(e=>e.Id==execution.Id);

            WFE.Status = execution.Status;
            WFE.Progress = execution.Progress;
            WFE.InitiatedBy = execution.InitiatedBy.Id;
            WFE.EndDate = DateTime.Now;

            db.WorkflowExecution.Update(WFE);
            db.SaveChanges();
            return WFE.Id;
        }

        public int UpdateWorkFlow(Common.Models.WorkFlow workFlow)
        {
            Entities.Workflow WF = db.Workflow.FirstOrDefault(w=>w.Id == workFlow.Id);

            WF.IsActive = workFlow.IsActive;

            db.Workflow.Update(WF);
            db.SaveChanges();
            return WF.Id;
        }

        public int UpdateWorkFlowActivityFields(Common.Models.WorkflowActivityField field)
        {
            Entities.WorkflowActivityField WAF = db.WorkflowActivityField.FirstOrDefault(w => w.Id == field.Id);

            WAF.Value = field.Value;

            db.WorkflowActivityField.Update(WAF);
            db.SaveChanges();
            return WAF.Id;
        }

        public ICollection<Common.Models.ActivityType> GetActivityTypes()
        {
            return db.WorkflowActivityType.Select(activityType => new Common.Models.ActivityType
            {
                Id = activityType.Id,
                Name = activityType.Name,
                FieldTypes = activityType.WorkflowActivityFieldType.Select(s=>new Common.Models.ActivityFieldType { Id = s.Id, ActivityType=s.ActivityType, Name=s.Name, DataType=s.DataType }).ToList()
            }).ToList();
        }
    }
}
