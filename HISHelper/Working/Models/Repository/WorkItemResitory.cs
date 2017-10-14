﻿using System;
using System.Collections.Generic;
using System.Linq;
using Working.Models.DataModel;

namespace Working.Model.Repository
{
    /// <summary>
    /// 活动仓储类
    /// </summary>
    public class WorkItemResitory : IWorkItemResitory
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        WorkingDbContext _dbContext;
        /// <summary>
        /// 权限仓储类构造
        /// </summary>
        /// <param name="dbContext">startup注入的数据库对象</param>
        public WorkItemResitory(WorkingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="workItem">工作记录</param>
        /// <returns></returns>
        public bool AddWorkItem(WorkItem workItem)
        {
            _dbContext.WorkItems.Add(workItem);
            var result = _dbContext.SaveChanges();
            return result > 0;
        }
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public WorkItem GetWorkItem(int id)
        {
            return _dbContext.WorkItems.SingleOrDefault(s => s.ID == id);
        }
        /// <summary>
        /// 按用户ID获取实体
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        public List<WorkItem> GetWorkItemsByUserID(int userID)
        {
            return _dbContext.WorkItems.Where(w => w.CreateUserID == userID).OrderByDescending(o => o.CreateTime).ToList();
        }
        /// <summary>
        /// 按用户，年，月获取用户工作记录
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <returns></returns>
        public List<WorkItem> GetWorkItemsByUserID(int userID,int year,int month)
        {
            var beginTime = DateTime.Parse($"{year}-{month}-01 00:00:00");
            var endTime = DateTime.Parse($"{year}-{month}-{DateTime.DaysInMonth(year,month)} 23:59:59");

            return _dbContext.WorkItems.Where(w => w.CreateUserID == userID&&w.RecordDate>=beginTime&&w.RecordDate<= endTime).OrderByDescending(o => o.CreateTime).ToList();
        }
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="newWorkItem">新实体</param>
        /// <returns></returns>
        public bool ModifyWorkItem(WorkItem newWorkItem)
        {
            var oldWorkItem = _dbContext.WorkItems.SingleOrDefault(s => s.ID == newWorkItem.ID);
            if (oldWorkItem == null)
            {
                return false;
            }
            else
            {
                oldWorkItem.WorkContent = newWorkItem.WorkContent;
                oldWorkItem.CreateUserID = newWorkItem.CreateUserID;
                oldWorkItem.RecordDate = newWorkItem.RecordDate;
                oldWorkItem.CreateTime = DateTime .Now;
                var result = _dbContext.SaveChanges();
                return result > 0;
            }
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="ID">实体ID</param>
        /// <returns></returns>
        public bool RemoveWorkItem(int ID)
        {
            var oldWorkItem = _dbContext.WorkItems.SingleOrDefault(s => s.ID ==ID);
            if (oldWorkItem == null)
            {
                return false;
            }
            else
            {
                _dbContext.WorkItems.Remove(oldWorkItem);
                 var result = _dbContext.SaveChanges();
                return result > 0;
            }
        }
    }
}