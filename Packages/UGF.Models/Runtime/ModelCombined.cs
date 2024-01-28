using System;
using System.Collections.Generic;

namespace UGF.Models.Runtime
{
    public class ModelCombined : IModelCopyable, IModelClearable
    {
        private readonly List<IModel> m_models = new List<IModel>();

        public bool Contains(IModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return m_models.Contains(model);
        }

        public void Add(IModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            m_models.Add(model);
        }

        public bool Remove(IModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return m_models.Remove(model);
        }

        public bool RemoveAll()
        {
            if (m_models.Count > 0)
            {
                m_models.Clear();
                return true;
            }

            return false;
        }

        public IReadOnlyList<IModel> GetModels()
        {
            return m_models.ToArray();
        }

        public void GetModels(ICollection<IModel> models)
        {
            if (models == null) throw new ArgumentNullException(nameof(models));

            for (int i = 0; i < m_models.Count; i++)
            {
                IModel model = m_models[i];

                models.Add(model);
            }
        }

        public void CopyFrom(IModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            if (model is not ModelCombined combinedModel) throw new ArgumentException($"Model must by type of '{nameof(ModelCombined)}'.");
            if (m_models.Count != combinedModel.m_models.Count) throw new ArgumentException("Models has different sub models count.");

            for (int i = 0; i < m_models.Count; i++)
            {
                IModel to = m_models[i];

                if (to is IModelCopyable toCopyable)
                {
                    IModel from = combinedModel.m_models[i];

                    toCopyable.CopyFrom(from);
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < m_models.Count; i++)
            {
                IModel model = m_models[i];

                if (model is IModelClearable clearable)
                {
                    clearable.Clear();
                }
            }
        }
    }
}
