using Source.CellManagement.Mono;
using Source.Level.Mono;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Source.CellManagement
{
    public class CellsFactory
    {
        [Inject] private readonly CellViewMono m_CellViewMonoPrefab;
        [Inject] private readonly LevelViewMono m_LevelViewMono;
        [Inject] private readonly IObjectResolver _objectResolver;

        public CellViewMono Create(Vector2Int position)
        {
            CellViewMono cellViewMono = _objectResolver.Instantiate(m_CellViewMonoPrefab, m_LevelViewMono.Transform);
            cellViewMono.SetPosition(position);
            return cellViewMono;
        }
    }
}