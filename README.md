## ASP.NET Core WebApi + Microsoft.EntityFrameworkCore 连接 Mysql/Sqlserver 项目架构

这是一个 .net Core 下的 webapi + EntityFrameworkCore 连接 Mysql/Sqlserver 的简单项目架构。  

主要包括四个子项目：  

   - DomainModel &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; **数据模型和DAO接口**
   - DataAccessProvider &nbsp; &nbsp;&nbsp; **自定义DbContext和DAO接口的实现**
   - JK.GISService  &nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;   **.net core webapi(api接口) 配置数据库连接，自定义DbContext 和 DAO接口实现类的依赖注入**
   - JK.GISApp  &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;      **.net core webapplication(前端页面和js)**
     
## 构建环境和核心引用库  
  
	.net core 1.0.1 
    "Microsoft.EntityFrameworkCore.SqlServer": "1.0.1",
    "SapientGuardian.EntityFrameworkCore.MySql": "7.1.14"
     "Microsoft.EntityFrameworkCore": "1.0.1",
    "Microsoft.EntityFrameworkCore.Design.Core": "1.0.0-preview2-final",
    "NETStandard.Library": "1.6.0"
         


### DomainModel 
  
- 包含用来测试的两个数据模型类   tabBaseInfo 和 tabProjectInfo 对应数据库中的 tabBaseInfo 表和 tabProjectInfo  
-   IDataAccessProvider 对数据模型进行操作的DAO接口    
       
           
            
    `public class tabBaseInfo {
        [Key]
        public Guid id { get; set; }
        /// <summary>        
        /// 初始化地图url
        /// </summary>
        public string initMapURL { get; set; }
        /// <summary>
        /// 地图坐标系
        /// </summary>
        public string mapProject { get; set; }
          
        /// <summary>
        /// 初始化位置x
        /// </summary>
        public double initX { get; set; }
        /// <summary>
        /// 初始化位置y
        /// </summary>
        public double initY { get; set; }
              
       /// <summary>
       /// 初始化缩放比例
       /// </summary>
        public double initScale { get; set; }
                  
        /// <summary>
        /// 初始化图层ID集合 已弃用
        /// </summary>
        public string initLayers { get; set; }
                  
        /// <summary>
        /// 是否开始加载图层列表
        /// </summary>
        public int addLayerList { get; set; }
            
        /// <summary>
        /// 是否开始加载鹰眼
        /// </summary>
        public int addOverviewMap { get; set; }
                
        /// <summary>
        /// 是否开始加载缩放比例
        /// </summary>
        public int addScaleLine { get; set; }
                
        /// <summary>
        /// 是否初始化加载比例尺
        /// </summary>
        public int addZoomBar { get; set; }
        /// <summary>
        /// 项目编号 关联项目表的主键
        /// </summary>
        public Guid pjid { get; set; }
    }
   
  
### DataAccessProvider
- 包含自定义DbContext 
- DataAccessMssqlProvider 对DomainModel.IDataAccessProvider 接口的实现，实现具体的业务操作  

       public class DomainModelContext : DbContext
    {

        public DomainModelContext(DbContextOptions<DomainModelContext> options) : base(options) {

        } 

        public DbSet<tabBaseInfo> tabBaseInfo { get; set; }
        public DbSet<tabProjectInfo> tabProjectInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<tabBaseInfo>().HasKey(m => m.id);
            builder.Entity<tabProjectInfo>().HasKey(m => m.id);

            base.OnModelCreating(builder);
        }


    }


### JK.GISService     
  
  webapi 项目 编写api接口 引用 DataAccessProvider子项目，配置DataAccessProvider 中自定义DbContext和 DAO的实现类DataAccessMssqlProvider 的依赖注入

#### 依赖注入配置说明 
 
在 startup.cs 中的方法 ConfigureServices 中增加 自定义DbContext和DAO的注入如下：  
  
    public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            string sqlConnectionString = null;
           string connType =  Configuration.GetSection("connType").Value;
            if ("mysql" == connType)
            {
                sqlConnectionString = Configuration.GetSection("ConnectionStrings:DataAccessMySqlProvider").Value;
                services.AddDbContext<DomainModelContext>(options =>
                        options.UseMySQL(
                            sqlConnectionString,
                            b => b.MigrationsAssembly("JK.GISService")
                        )
                     );

            }
            else {
                sqlConnectionString = Configuration.GetSection("ConnectionStrings:DataAccessMsSqlServerProvider").Value;
                services.AddDbContext<DomainModelContext>(options =>
                    options.UseSqlServer(
                        sqlConnectionString
                    ) );
               
            }
            services.AddScoped<IDataAccessProvider, DataAccessMssqlProvider>();

        }
`
 


### JK.GISApp ###  


前端web项目
 