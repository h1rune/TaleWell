import { useEffect, useState } from 'react';
import { ChannelListItemProps } from 'shared/ui/channel_list_item/ChannelListItem';
import { getChannels } from './ChannelList.api';

export const useChannels = () => {
  const [data, setData] = useState<ChannelListItemProps[] | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getChannels()
      .then(setData)
      .catch((error) => setError(error.message))
      .finally(() => setLoading(false));
  }, []);

  return { data, loading, error };
};
