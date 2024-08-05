using AbPlcEmulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbPlcEmulator.View
{
    public interface IAbPlcEmulatorView
    {
        event EventHandler ServerOpenRequested;
        event EventHandler ServerCloseRequested;
        event EventHandler<ChangedTagsEventArgs> ConfirmTagRequested;
        event EventHandler<TagFilePathChangedEventArgs> TagFilePathChanged;
        event EventHandler<CellChangedEventArgs> TagChangingStarted;
        event EventHandler<CellChangedEventArgs> TagInvalidInputRequired;
        event EventHandler<FormClosingEventArgs> ProgramExitRequested;
        event EventHandler<SetTagValueEventArgs> SetTagValueRequested;
        event EventHandler<ChangedTagsEventArgs> ShowValuesRequested;

        bool IsServerOpening { get; set; }
        object ServerInfoGridDataSource { set; }
        string TagFilePath { get; set; }

        void ShowTags(Dictionary<string, TagInfo> tags);

        void RetriveInvalidValue(int rowIndex, int columnIndex, object value);

        void ShowTagConfirmed();

        void ShowServerOpenInfo(bool serverOpened);

        void ShowValues(Dictionary<string, string> values);

        void ShowDefaultValues();
    }
}
