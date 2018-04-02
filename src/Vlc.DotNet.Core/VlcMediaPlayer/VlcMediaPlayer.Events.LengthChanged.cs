﻿using System;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Core.Interops.Signatures;

namespace Vlc.DotNet.Core
{
    public sealed partial class VlcMediaPlayer
    {
        private EventCallback myOnMediaPlayerLengthChangedInternalEventCallback;
        public event EventHandler<VlcMediaPlayerLengthChangedEventArgs> LengthChanged;

        private void OnMediaPlayerLengthChangedInternal(IntPtr ptr)
        {
            var args = MarshalHelper.PtrToStructure<VlcEventArg>(ptr);
            OnMediaPlayerLengthChanged(args.eventArgsUnion.MediaPlayerLengthChanged.NewLength * 10000);
        }

        public void OnMediaPlayerLengthChanged(float newLength)
        {
            LengthChanged?.Invoke(this, new VlcMediaPlayerLengthChangedEventArgs(newLength));
        }
    }
}