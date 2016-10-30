namespace TemplateMethodPattern.Contracts
{
    /// <summary>
    /// Defines information for exporting data in different format types.
    /// </summary>
    public interface IExporter
    {
        /// <summary>
        /// Defines information for reading data.
        /// </summary>
        void ReadData();

        /// <summary>
        /// Defines information for formatting data.
        /// </summary>
        void FormatData();

        /// <summary>
        /// Defines information for formatting data.
        /// </summary>
        /// <returns>Exporting data</returns>
        string ExportData();

        /// <summary>
        /// Defines information for exporting formatted data.
        /// </summary>
        void ExportFormattedData();
    }
}