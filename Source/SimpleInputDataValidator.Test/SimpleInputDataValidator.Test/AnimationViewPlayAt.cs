using Lottie.Forms;
using Xamarin.Forms;

namespace SimpleInputDataValidator.Test
{
    public class AnimationViewPlayAt
    {
        public static readonly BindableProperty PlayAtProgressToProperty =
            BindableProperty.CreateAttached("PlayAtProgressTo", typeof(float), typeof(AnimationView), 1f, propertyChanged: OnPlayAtProgressToChanged);

        private static void OnPlayAtProgressToChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SetPlayAtProgressTo(bindable, (float)newValue);
        }

        public static float GetPlayAtProgressTo(BindableObject view)
        {
            return (float)view.GetValue(PlayAtProgressToProperty);
        }

        public static void SetPlayAtProgressTo(BindableObject view, float value)
        {
            view.SetValue(PlayAtProgressToProperty, value);
        }


        public static readonly BindableProperty PlayAtProgressFromProperty =
            BindableProperty.CreateAttached("PlayAtProgressFrom", typeof(float), typeof(AnimationView), 0f, propertyChanged: OnPlayAtProgressFromChanged);

        private static void OnPlayAtProgressFromChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SetPlayAtProgressFrom(bindable, (float)newValue);
        }

        public static float GetPlayAtProgressFrom(BindableObject view)
        {
            return (float)view.GetValue(PlayAtProgressFromProperty);
        }

        public static void SetPlayAtProgressFrom(BindableObject view, float value)
        {
            view.SetValue(PlayAtProgressFromProperty, value);
        }


        public static readonly BindableProperty StartPlayAtProgressSegmentProperty =
            BindableProperty.CreateAttached("StartPlayAtProgressSegment", typeof(bool), typeof(AnimationView), false, propertyChanged: OnStartPlayAtProgressSegmentChanged);

        private static void OnStartPlayAtProgressSegmentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            SetStartPlayAtProgressSegment(bindable, (bool)newValue);
        }

        public static bool GetStartPlayAtProgressSegment(BindableObject view)
        {
            return (bool)view.GetValue(StartPlayAtProgressSegmentProperty);
        }

        public static void SetStartPlayAtProgressSegment(BindableObject view, bool value)
        {
            view.SetValue(StartPlayAtProgressSegmentProperty, value);

            if(value)
                (view as AnimationView).PlayProgressSegment(
                    GetPlayAtProgressFrom(view),
                    GetPlayAtProgressTo(view));
        }
    }
}
