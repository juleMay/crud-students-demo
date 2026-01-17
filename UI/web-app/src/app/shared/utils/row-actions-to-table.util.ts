import { RowActionRule, Table } from "../models/table.model";

export function rowActionsToTable(
  table: Table,
  rules: RowActionRule[]
): Table {
  if (!table.hasActions) {
    return table;
  }

  const updatedRows = table.rows.map(row => {
    const matchingRule = rules.find(rule => rule.when(row));

    return {
      ...row,
      actions: matchingRule ? matchingRule.actions : [],
    };
  });

  return {
    ...table,
    rows: updatedRows,
  };
}
