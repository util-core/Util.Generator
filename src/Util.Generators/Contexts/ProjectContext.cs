using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Data;
using Util.Generators.Properties;
using Util.Validation;

namespace Util.Generators.Contexts {
    /// <summary>
    /// 项目上下文
    /// </summary>
    public class ProjectContext {
        /// <summary>
        /// 初始化项目上下文
        /// </summary>
        public ProjectContext( GeneratorContext generatorContext ) {
            GeneratorContext = generatorContext ?? throw new ArgumentNullException( nameof( generatorContext ) );
            Entities = new List<EntityContext>();
            Schemas = new List<string>();
            Id = Util.Helpers.Id.Create();
        }

        /// <summary>
        /// 项目标识
        /// </summary>
        public string Id { get; private init; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required(ErrorMessageResourceType = typeof( GeneratorResource ),ErrorMessageResourceName = "ProjectNameIsEmpty")]
        public string Name { get; set; }

        /// <summary>
        /// 目标数据库类型
        /// </summary>
        public DatabaseType TargetDbType { get; set; }

        /// <summary>
        /// 工作单元名称
        /// </summary>
        public string UnitOfWorkName { get; set; }

        /// <summary>
        /// 前端应用名称
        /// </summary>
        public string ClientAppName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 是否使用Utc
        /// </summary>
        public bool Utc { get; set; }

        /// <summary>
        /// 生成器上下文
        /// </summary>
        public GeneratorContext GeneratorContext { get; }

        /// <summary>
        /// 实体上下文列表
        /// </summary>
        public List<EntityContext> Entities { get; }

        /// <summary>
        /// 架构列表
        /// </summary>
        public List<string> Schemas { get; }

        /// <summary>
        /// 验证
        /// </summary>
        public void Validate() {
            var validationResult = DataAnnotationValidation.Validate( this );
            if( validationResult.IsValid )
                return;
            throw new InvalidOperationException( validationResult.First().ErrorMessage );
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="generatorContext">生成器上下文</param>
        public ProjectContext Clone( GeneratorContext generatorContext ) {
            var result = new ProjectContext( generatorContext ) {
                Id = Id,
                Name = Name,
                UnitOfWorkName = UnitOfWorkName,
                ClientAppName = ClientAppName,
                TargetDbType = TargetDbType,
                Enabled = Enabled,
                Utc = Utc
            };
            result.Schemas.AddRange( Schemas );
            Entities.ForEach( entity => result.Entities.Add( entity.Clone( result ) ) );
            return result;
        }
    }
}
