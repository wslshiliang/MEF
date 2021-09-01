using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityModel.Sys
{
    public partial class BaseModel
    {
        /// <summary>
        /// 主键，自增Int值
        /// </summary>
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 是否可用 true代表此条数据可用， FALSE代表此条数据不在可用
        /// </summary>
        public bool IsUsed { get; internal set; }
        /// <summary>
        /// 创建人信息，建议使用UserName
        /// </summary>
        public string CrtUser { get; internal set; }
        /// <summary>
        /// 创建时间，DateTime值
        /// </summary>
        public DateTime CrtTime { get; internal set; }
        /// <summary>
        /// 修改人，建议使用UserName
        /// </summary>
        public string EdtUser { get; internal set; }
        /// <summary>
        /// 修改时间，可为空，空则代表为无修改
        /// </summary>
        public DateTime? EdtTime { get; internal set; }
        /// <summary>
        /// 备注信息，最大字符长度，可存储任意数据，不建议把业务数据放入到此字段
        /// </summary>
        public string Remark { get; internal set; }
    }
}
