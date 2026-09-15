import { createContext, useContext, useState, type ReactNode } from 'react'
import type { UserRole } from './types'

interface RoleContextValue {
  role: UserRole
  setRole: (role: UserRole) => void
}

const RoleContext = createContext<RoleContextValue | undefined>(undefined)

/**
 * Stands in for real authentication, which doesn't exist in this app yet:
 * lets a developer/tester switch which role they're "acting as". The chosen
 * role is sent to the backend as the X-User-Role header (see api.ts).
 */
export function RoleProvider({ children }: { children: ReactNode }) {
  const [role, setRole] = useState<UserRole>('Admin')
  return <RoleContext.Provider value={{ role, setRole }}>{children}</RoleContext.Provider>
}

export function useRole() {
  const context = useContext(RoleContext)
  if (!context) {
    throw new Error('useRole must be used within a RoleProvider')
  }
  return context
}
