using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

namespace WisdomTree.NoName.Function
{
    /// <summary>
    /// WebGL全屏/退出全屏接口
    /// </summary>
    public class WebGLFullScreen
    {
        /// <summary>
        /// 全屏Js引用
        /// </summary>
        [DllImport("__Internal")]
        private static extern void UnityFullScreen();

        /// <summary>
        /// 退出全屏Js引用
        /// </summary>
        [DllImport("__Internal")]
        private static extern void UnitySmallScreen();

        /// <summary>
        /// 全屏
        /// </summary>
        public static void FullScreen()
        {
            try
            {
                UnityFullScreen();
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.LogError(e);
            }
        }

        /// <summary>
        /// 窗口化
        /// </summary>
        public static void Windowed()
        {
            try
            {
                UnitySmallScreen();
            }
            catch (EntryPointNotFoundException e)
            {
                Debug.LogError(e);
            }
        }
    }
}