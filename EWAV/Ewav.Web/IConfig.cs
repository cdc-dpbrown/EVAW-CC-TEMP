namespace Epi.DataSets
{
    public interface IConfig
    {
        Epi.DataSets.Config.ConnectionsDataTable Connections { get; }
        Epi.DataSets.Config.DatabaseDataTable Database { get; }
        Epi.DataSets.Config.DataDriverDataTable DataDriver { get; }
        Epi.DataSets.Config.DataDriversDataTable DataDrivers { get; }
        Epi.DataSets.Config.DataSourcesDataTable DataSources { get; }
        Epi.DataSets.Config.DirectoriesDataTable Directories { get; }
        Epi.DataSets.Config.FileDataTable File { get; }
        Epi.DataSets.Config.ModuleDataTable Module { get; }
        Epi.DataSets.Config.ModulesDataTable Modules { get; }
        Epi.DataSets.Config.PermanentVariableDataTable PermanentVariable { get; }
        Epi.DataSets.Config.ProjectsDataTable Projects { get; }
        Epi.DataSets.Config.RecentDataSourceDataTable RecentDataSource { get; }
        Epi.DataSets.Config.RecentProjectDataTable RecentProject { get; }
        Epi.DataSets.Config.RecentViewDataTable RecentView { get; }
        System.Data.DataRelationCollection Relations { get; }
        System.Data.SchemaSerializationMode SchemaSerializationMode { get; set; }
        Epi.DataSets.Config.SettingsDataTable Settings { get; }
        System.Data.DataTableCollection Tables { get; }
        Epi.DataSets.Config.VariablesDataTable Variables { get; }
        Epi.DataSets.Config.VersionDataTable Version { get; }
        Epi.DataSets.Config.ViewsDataTable Views { get; }
        System.Data.DataSet Clone();
    }
}