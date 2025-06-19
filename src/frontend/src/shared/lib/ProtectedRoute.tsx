import { Navigate } from "react-router-dom";
import { ReactNode } from "react";
import { useChannelStore } from "entities/channel/store";

interface ProtectedRouteProps {
  children: ReactNode;
}

export const ProtectedRoute = ({ children }: ProtectedRouteProps) => {
  const ownChannel = useChannelStore((state) => state.channel);

  if (!ownChannel) {
    return <Navigate to="/login" replace />;
  }
  return <>{children}</>;
};