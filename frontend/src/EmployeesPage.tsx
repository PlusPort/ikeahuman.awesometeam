import { useEffect, useState } from 'react'
import {
  createEmployee,
  getEmployees,
  getRoles,
  getSites,
  updateEmployee,
  type Employee,
  type EmployeeInput,
} from './api'
import { EmployeeForm } from './EmployeeForm'
import { useRole } from './RoleContext'
import type { LookupItem } from './types'

export function EmployeesPage() {
  const { role, setRole } = useRole()
  const [employees, setEmployees] = useState<Employee[]>([])
  const [sites, setSites] = useState<LookupItem[]>([])
  const [roles, setRoles] = useState<LookupItem[]>([])
  const [editing, setEditing] = useState<Employee | 'new' | null>(null)
  const [loadError, setLoadError] = useState<string | null>(null)

  const isAdmin = role === 'Admin'

  const loadAll = async () => {
    try {
      const [employeesData, sitesData, rolesData] = await Promise.all([
        getEmployees(role),
        getSites(role),
        getRoles(role),
      ])
      setEmployees(employeesData)
      setSites(sitesData)
      setRoles(rolesData)
      setLoadError(null)
    } catch (err) {
      setLoadError(err instanceof Error ? err.message : 'Failed to load employees.')
    }
  }

  useEffect(() => {
    loadAll()
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [role])

  const siteName = (id: number) => sites.find((s) => s.id === id)?.name ?? 'Unknown site'
  const roleName = (id: number) => roles.find((r) => r.id === id)?.name ?? 'Unknown role'

  const handleSubmit = async (input: EmployeeInput) => {
    if (editing === 'new') {
      await createEmployee(role, input)
    } else if (editing) {
      await updateEmployee(role, editing.id, input)
    }
    setEditing(null)
    await loadAll()
  }

  return (
    <section>
      <h1>Employees</h1>

      <label htmlFor="acting-as">Acting as</label>
      <select id="acting-as" value={role} onChange={(e) => setRole(e.target.value as 'Admin' | 'User')}>
        <option value="Admin">Admin</option>
        <option value="User">User</option>
      </select>

      {loadError && <p role="alert">{loadError}</p>}

      {editing && sites.length > 0 && roles.length > 0 && (
        <EmployeeForm
          employee={editing === 'new' ? undefined : editing}
          sites={sites}
          roles={roles}
          onSubmit={handleSubmit}
          onCancel={() => setEditing(null)}
        />
      )}

      {isAdmin && !editing && (
        <button type="button" onClick={() => setEditing('new')}>
          Add employee
        </button>
      )}

      <ul>
        {employees.map((employee) => (
          <li key={employee.id}>
            {employee.name} — {siteName(employee.siteId)} — {roleName(employee.roleId)}
            {isAdmin && !editing && (
              <button type="button" onClick={() => setEditing(employee)}>
                Edit
              </button>
            )}
          </li>
        ))}
      </ul>
    </section>
  )
}
