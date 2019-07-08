using System;

namespace ALEXFW.Entity.UserAndRole
{
    /// <summary>
    /// 角色定义，Flag特性，取值为2的幂，如：1，2，4，8，16，32 
    /// </summary>
    [Flags]
    public enum AdminGroup
    {

        
        学生服务中心管理员 = 8,
        学生服务中心队长 = 4,
        服务中心维修人员 = 2,  
        在校学生=1,
        
    }
}