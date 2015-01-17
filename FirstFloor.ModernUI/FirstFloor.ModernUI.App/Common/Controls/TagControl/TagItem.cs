using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FirstFloor.ModernUI.App.Common.Controls.TagControl
{
    [TemplatePart(Name = "PART_InputBox", Type = typeof(AutoCompleteBox))]
    [TemplatePart(Name = "PART_DeleteTagButton", Type = typeof(Button))]
    [TemplatePart(Name = "PART_TagButton", Type = typeof(Button))]
    public class TagItem : Control
    {

        static TagItem()
        {
            // lookless control, get default style from generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TagItem), new FrameworkPropertyMetadata(typeof(TagItem)));
        }

        public TagItem() { }
        //public TagItem(string text)
        //    : this()
        //{
        //    this.Text = text;
        //}

        // Text
        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TagItem), new PropertyMetadata(null));

        //// Id
        //public int? Id { get { return (int?)GetValue(IdProperty); } set { SetValue(IdProperty, value); } }
        //public static readonly DependencyProperty IdProperty = DependencyProperty.Register("Id", typeof(int?), typeof(TagItem), new PropertyMetadata(null));

        // Item
        public Tag Item { get { return (Tag)GetValue(ItemProperty); } set { SetValue(ItemProperty, value); } }
        public static readonly DependencyProperty ItemProperty = DependencyProperty.Register("Item", typeof(Tag), typeof(TagItem), new PropertyMetadata(null));

        // IsEditing, readonly
        public bool IsEditing { get { return (bool)GetValue(IsEditingProperty); } internal set { SetValue(IsEditingPropertyKey, value); } }
        private static readonly DependencyPropertyKey IsEditingPropertyKey = DependencyProperty.RegisterReadOnly("IsEditing", typeof(bool), typeof(TagItem), new FrameworkPropertyMetadata(false));
        public static readonly DependencyProperty IsEditingProperty = IsEditingPropertyKey.DependencyProperty;

        private bool _isSomeChildGotFocus = false;
        private bool _firstAttempt = true;
        /// <summary>
        /// Wires up delete button click and focus lost 
        /// </summary>
        public override void OnApplyTemplate()
        {
            var inputBox = this.GetTemplateChild("PART_InputBox") as AutoCompleteBox;
            if (inputBox != null)
            {
                var tagControl = FindUpVisualTree<FirstFloor.ModernUI.App.Common.Controls.TagControl.TagControl>(inputBox);
                tagControl.PreviewKeyDown += (s, e) =>
                {
                    if (e.Key == Key.Tab || e.Key == Key.Enter)
                    {
                        DoneEditing();
                    }
                };
                tagControl.PreviewLostKeyboardFocus += inputBox_LostFocus;
                tagControl.LostFocus += (s, e) =>
                {
                    var focusedOn = FocusManager.GetFocusedElement(FindUpVisualTree<MainWindow>(tagControl));
                    //if(there is something that you are focusing on && it's not in a popup cuz it's not part of the visual tree)
                    if (focusedOn != null && !(focusedOn is ListBoxItem))
                    {
                        var isTagControl = HasParentTypeOf<FirstFloor.ModernUI.App.Common.Controls.TagControl.TagControl>(focusedOn as DependencyObject);
                        //if(the focus is outside the hole control)
                        if (!isTagControl)
                            DoneEditing();
                    }
                };

                tagControl.PreviewGotKeyboardFocus += (s, e) =>
                {
                    _isSomeChildGotFocus = true;
                    Debug.WriteLine("_isSomeChildGotFocus = true");
                };
                //inputBox.LostFocus += inputBox_LostFocus;
                inputBox.Loaded += inputBox_Loaded;
            }

            Button btn = this.GetTemplateChild("PART_TagButton") as Button;
            if (btn != null)
            {
                btn.Loaded += (s, e) =>
                {
                    Button b = s as Button;
                    var btnDelete = b.Template.FindName("PART_DeleteTagButton", b) as Button; // will only be found once button is loaded
                    if (btnDelete != null)
                    {
                        btnDelete.Click -= btnDelete_Click; // make sure the handler is applied just once
                        btnDelete.Click += btnDelete_Click;
                    }
                };

                btn.Click += (s, e) =>
                {
                    var parent = GetParent();
                    if (parent != null)
                        parent.RaiseTagClick(this); // raise the TagClick event of the TagControl
                };
            }

            base.OnApplyTemplate();
        }

        /// <summary>
        /// Set IsEditing to false when the AutoCompleteBox loses keyboard focus.
        /// This will change the template, displaying the tag as a button.
        /// </summary>
        void inputBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!_firstAttempt && !_isSomeChildGotFocus)
                DoneEditing();

            _isSomeChildGotFocus = false;
            _firstAttempt = false;
            Debug.WriteLine("_isSomeChildGotFocus = False");
        }


        /// <summary>
        /// Handles the click on the delete glyph of the tag button.
        /// Removes the tag from the collection.
        /// </summary>
        void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            var item = FindUpVisualTree<TagItem>(sender as FrameworkElement);
            var parent = GetParent();
            if (item != null && parent != null)
                parent.RemoveTag(item);

            e.Handled = true; // bubbling would raise the tag click event
        }

        /// <summary>
        /// When an AutoCompleteBox is created, set the focus to the textbox.
        /// Wire PreviewKeyDown event to handle Escape/Enter keys
        /// </summary>
        /// <remarks>AutoCompleteBox.Focus() is broken: http://stackoverflow.com/questions/3572299/autocompletebox-focus-in-wpf</remarks>
        void inputBox_Loaded(object sender, RoutedEventArgs e)
        {
            AutoCompleteBox acb = sender as AutoCompleteBox;
            if (acb != null)
            {
                var tb = acb.Template.FindName("Text", acb) as TextBox;
                if (tb != null)
                    tb.Focus();

                // PreviewKeyDown, because KeyDown does not bubble up for Enter
                acb.PreviewKeyDown += (s, e1) =>
                {
                    var parent = GetParent();
                    if (parent != null)
                    {
                        switch (e1.Key)
                        {
                            case (Key.Enter):  // accept tag
                                parent.Focus();
                                break;
                            case (Key.Escape): // reject tag
                                parent.Focus();
                                //parent.RemoveTag(this, true); // do not raise RemoveTag event
                                DoneEditing();
                                break;
                        }
                    }
                };
            }
        }
        private void DoneEditing()
        {
            IsEditing = false;
            var parent = GetParent();
            if (parent != null)
                parent.IsEditing = false;
        }

        private FirstFloor.ModernUI.App.Common.Controls.TagControl.TagControl GetParent()
        {
            return FindUpVisualTree<FirstFloor.ModernUI.App.Common.Controls.TagControl.TagControl>(this);
        }

        /// <summary>
        /// Walks up the visual tree to find object of type T, starting from initial object
        /// http://www.codeproject.com/Tips/75816/Walk-up-the-Visual-Tree
        /// </summary>
        private static T FindUpVisualTree<T>(DependencyObject initial) where T : DependencyObject
        {
            DependencyObject current = initial;
            while (current != null && current.GetType() != typeof(T))
            {
                current = VisualTreeHelper.GetParent(current);
            }
            return current as T;
        }

        private bool HasParentTypeOf<T>(DependencyObject item) where T : DependencyObject
        {
            return FindUpVisualTree<T>(item) != null;
        }
    }
}
