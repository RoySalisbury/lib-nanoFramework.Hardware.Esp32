using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32
{
    internal static class NativeMethods
    {
        static NativeMethods()
        {
            // Initialize the ESP32 timers
            NativeEspTimerInit();

            // Cleanup code 
            // ???? Technically not sure if this is even needed.  But might be for things like Lite/Deep sleep modes. ????
            //AppDomain.CurrentDomain.ProcessExit += (s, e) => 
            //{
            //    NativeEspTimerDeInit();
            //};
        }

        /// <summary>
        /// Get time in microseconds since boot.
        /// </summary>
        /// <returns>Number of microseconds since esp_timer_init was called (this normally happens early during application startup).</returns>
        public static long EspTimerGetTime()
        {
            return NativeEspTimerGetTime();
        }

        #region
        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEspTimerInit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern EspNativeError NativeEspTimerDeInit();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern long NativeEspTimerGetTime();
        #endregion
    }
}
