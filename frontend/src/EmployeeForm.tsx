import { useState, type FormEvent } from 'react'
import type { Employee, EmployeeInput } from './api'
import type { LookupItem } from './types'

interface EmployeeFormProps {
  employee?: Employee
  sites: LookupItem[]
  roles: LookupItem[]
  onSubmit: (input: EmployeeInput) => Promise<void>
  onCancel: () => void
}

export function EmployeeForm({ employee, sites, roles, onSubmit, onCancel }: EmployeeFormProps) {
  const [name, setName] = useState(employee?.name ?? '')
  const [siteId, setSiteId] = useState(employee?.siteId ?? sites[0]?.id ?? 0)
  const [roleId, setRoleId] = useState(employee?.roleId ?? roles[0]?.id ?? 0)
  const [error, setError] = useState<string | null>(null)
  const [submitting, setSubmitting] = useState(false)

  const handleSubmit = async (event: FormEvent) => {
    event.preventDefault()
    if (!name.trim()) {
      setError('Name is required.')
      return
    }

    setSubmitting(true)
    setError(null)
    try {
      await onSubmit({ name: name.trim(), siteId, roleId })
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to save employee.')
    } finally {
      setSubmitting(false)
    }
  }

  return (
    <form onSubmit={handleSubmit} aria-label={employee ? 'Edit employee' : 'Add employee'}>
      <label htmlFor="employee-name">Name</label>
      <input
        id="employee-name"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <label htmlFor="employee-site">Site</label>
      <select id="employee-site" value={siteId} onChange={(e) => setSiteId(Number(e.target.value))}>
        {sites.map((site) => (
          <option key={site.id} value={site.id}>
            {site.name}
          </option>
        ))}
      </select>

      <label htmlFor="employee-role">Role</label>
      <select id="employee-role" value={roleId} onChange={(e) => setRoleId(Number(e.target.value))}>
        {roles.map((role) => (
          <option key={role.id} value={role.id}>
            {role.name}
          </option>
        ))}
      </select>

      {error && <p role="alert">{error}</p>}

      <button type="submit" disabled={submitting}>
        {employee ? 'Save changes' : 'Add employee'}
      </button>
      <button type="button" onClick={onCancel} disabled={submitting}>
        Cancel
      </button>
    </form>
  )
}
