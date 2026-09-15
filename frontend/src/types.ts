export interface Employee {
  id: number
  name: string
  siteId: number
  roleId: number
}

export interface LookupItem {
  id: number
  name: string
}

export type UserRole = 'Admin' | 'User'
