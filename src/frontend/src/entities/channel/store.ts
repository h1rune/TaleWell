import { create } from 'zustand';
import { persist } from 'zustand/middleware';
import { Channel } from './channel';

interface ChannelState {
  channel: Channel | null;
  setChannel: (channel: Channel) => void;
  clearChannel: () => void;
}

export const useChannelStore = create<ChannelState>()(
  persist(
    (set) => ({
      channel: null,
      setChannel: (channel) => set({ channel }),
      clearChannel: () => set({ channel: null }),
    }),
    {
      name: 'channel-storage',
    }
  )
);
