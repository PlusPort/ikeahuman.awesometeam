import type { Employee, LookupItem, UserRole } from './types'

export type { Employee }

async function request<T>(path: string, role: UserRole, init?: RequestInit): Promise<T> {
  const response = await fetch(path, {
    ...init,
    headers: {
      'Content-Type': 'application/json',
      'X-User-Role': role,
      ...init?.headers,
    },
  })

  if (!response.ok) {
    const problem = await response.json().catch(() => null)
    throw new Error(problem?.title ?? problem?.message ?? `Request to ${path} failed with ${response.status}`)
  }

  if (response.status === 204) {
    return undefined as T
  }

  return response.json() as Promise<T>
}

export function getEmployees(role: UserRole) {
  return request<Employee[]>('/employees', role)
}

export function getSites(role: UserRole) {
  return request<LookupItem[]>('/sites', role)
}

export function getRoles(role: UserRole) {
  return request<LookupItem[]>('/roles', role)
}

export interface EmployeeInput {
  name: string
  siteId: number
  roleId: number
}

export function createEmployee(role: UserRole, input: EmployeeInput) {
  return request<Employee>('/employees', role, {
    method: 'POST',
    body: JSON.stringify(input),
  })
}

export function updateEmployee(role: UserRole, id: number, input: EmployeeInput) {
  return request<Employee>(`/employees/${id}`, role, {
    method: 'PUT',
    body: JSON.stringify(input),
  })
}
