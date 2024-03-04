mergeInto(LibraryManager.library,
{
  MakePopupAppear: function (sender, popupDescription)
  {
    var enteredText = window.prompt(UTF8ToString(popupDescription), UTF8ToString(""));

    var text;

    if (enteredText == null || enteredText == "")
    {
      text = UTF8ToString("");
    }
    else
    {
      text = enteredText;
    }

    window.focus();

    SendMessage(UTF8ToString(sender), 'ReceiveEnterdText', String(text));
  }
});